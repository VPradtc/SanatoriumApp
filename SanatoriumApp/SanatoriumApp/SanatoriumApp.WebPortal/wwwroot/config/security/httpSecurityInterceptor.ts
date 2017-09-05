module pinguinPortal.app.config.security {
    import AuthService = pinguinPortal.app.auth.services.AuthService;

    interface ISuspendedHttpRequest {
        data: ng.IRequestConfig,
        deferred: ng.IDeferred<any>,
    }

    class HttpSecurityInterceptor implements ng.IHttpInterceptor {
        static $inject = [
            '$q',
            '$injector',
        ];

        constructor(
            private readonly $q: ng.IQService
            , private readonly $injector: ng.auto.IInjectorService) {
        }

        private refreshTokenInProgress: boolean = false;
        private pendingRequests: ISuspendedHttpRequest[] = [];

        private redirectToLogin(rejection: any, deferred: ng.IDeferred<any>): void {

            var authService = <AuthService>this.$injector.get('authService');
            authService.logout();
            deferred.reject(rejection);
        }

        private retryHttpRequest(request: ISuspendedHttpRequest): void {
            var $http = <ng.IHttpService>this.$injector.get('$http');
            $http(request.data).then((response: any) => {
                request.deferred.resolve(response);
            });
        }

        public request = (config: ng.IRequestConfig) => {

            config.headers = config.headers || {};

            var authService = <AuthService>this.$injector.get('authService');
            var token = authService.authData.accessToken;

            if (token !== null) {
                config.headers.Authorization = 'Bearer ' + token;
            }

            return config;
        }

        public responseError = (rejection: any) => {
            var deferred = this.$q.defer();

            var authService = <AuthService>this.$injector.get('authService');

            if (rejection.status !== 401) {

                deferred.reject(rejection);

                return deferred.promise;
            }

            var authData = authService.authData;

            if (!authData.isAuthenticated) {

                this.redirectToLogin(rejection, deferred);

                return deferred;
            }

            this.pendingRequests.push({
                data: rejection.config,
                deferred: deferred
            });

            if (this.refreshTokenInProgress === true) {
                return deferred.promise;
            }

            this.refreshTokenInProgress = true;

            authService.renewAccessToken().then((response: any) => {

                this.refreshTokenInProgress = false;

                for (var i = 0; i < this.pendingRequests.length; i++) {
                    this.retryHttpRequest(this.pendingRequests[i]);
                }

                this.pendingRequests = [];
            }, () => {
                this.refreshTokenInProgress = false;
                this.redirectToLogin(rejection, deferred);
            });

            return deferred.promise;
        }
    }

    function HttpSecurityInterceptorFactory(
        $q: ng.IQService
        , $injector: ng.auto.IInjectorService): ng.IHttpInterceptor {

        return new HttpSecurityInterceptor($q, $injector);
    }

    HttpSecurityInterceptorFactory.$inject = [
        '$q',
        '$injector',
    ];

    angular.module('pinguinPortal').config([
        '$httpProvider', ($httpProvider: ng.IHttpProvider) => {
            $httpProvider.interceptors.push(HttpSecurityInterceptorFactory);
        }
    ]);
}