module pinguinPortal.app.auth.services {

    import AuthData = auth.models.AuthData;
    import CompanyTypeIdentifier = app.core.models.enums.CompanyTypeIdentifier;
    import UrlSettings = app.config.UrlSettings;

    import PasswordAuthRequest = pinguinPortal.app.auth.models.PasswordAuthRequest;
    import RefreshTokenAuthRequest = pinguinPortal.app.auth.models.RefreshTokenAuthRequest;

    export class AuthService {
        static $inject = [
            '$state',
            '$http',
            '$httpParamSerializerJQLike',
            '$q',
            '$localStorage',
        ];

        private readonly authDataKey: string = 'ix-user-auth-data';

        public authData: AuthData;

        constructor(
            private readonly $state: ng.ui.IStateService
            , private readonly $http: ng.IHttpService
            , private readonly $httpParamSerializerJQLike: ng.IHttpParamSerializer
            , private readonly $q: ng.IQService
            , private readonly $localStorage: angular.storage.IStorageService
        ) {
            this.reloadAuthData();
        }

        private save(authData: AuthData): void {

            this.$localStorage[this.authDataKey] = authData;
            this.reloadAuthData();
        }

        private reloadAuthData(): void {

            var savedUserInfo = <AuthData>this.$localStorage[this.authDataKey];

            if (savedUserInfo === undefined
                || savedUserInfo.isAuthenticated === false) {

                this.clearAuthData();

                return;
            }

            this.authData = angular.copy(savedUserInfo);
        }

        private clearAuthData(): void {
            var pristineAuthData: AuthData = {
                firstName: '',
                lastName: '',
                role: null,
                refreshToken: null,
                accessToken: null,
                isAuthenticated: false,
            };

            if (this.authData === undefined) {
                this.authData = pristineAuthData;
            } else {
                angular.extend(this.authData, pristineAuthData);
            }
        }

        public login(request: PasswordAuthRequest): ng.IPromise<any> {

            var deferred = this.$q.defer();

            this.$http.post<AuthData>(
                UrlSettings.tokenUrl
                , this.$httpParamSerializerJQLike(request)
                , { headers: { 'Content-Type': 'application/x-www-form-urlencoded' }, }
            )
                .then((response: AuthData) => {

                    this.save(response);
                    deferred.resolve(response);
                }, (err) => {
                    deferred.reject(err);
                });

            return deferred.promise;
        }

        public _isAuthorized(): boolean {
            return this.authData.isAuthenticated === true;
        }

        public checkRole(role: CompanyTypeIdentifier): boolean {
            return this.authData.role === role;
        }

        public logout(): void {

            this.clearAuthData();
            this.$state.go('signin.login');
        }

        public renewAccessToken(): ng.IPromise<any> {

            var deferred = this.$q.defer();

            if (!this.authData.isAuthenticated) {
                deferred.reject();

                return deferred.promise;
            }

            var request = new RefreshTokenAuthRequest(
                'refresh_token'
                , this.authData.refreshToken
                , UrlSettings.clientId
            );

            this.$http.post<AuthData>(UrlSettings.tokenUrl, request, { headers: { 'Content-Type': 'application/x-www-form-urlencoded', }, })
                .then((authData: AuthData) => {

                    this.save(authData);
                    deferred.resolve();

                }, (reason) => {
                    this.clearAuthData();
                    deferred.reject(reason);

                    this.logout();
                });

            return deferred.promise;
        }
    }

    angular.module('pinguinPortal').service('authService', AuthService);
}
