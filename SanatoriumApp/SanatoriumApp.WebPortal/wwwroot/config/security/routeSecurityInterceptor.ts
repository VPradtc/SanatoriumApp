module pinguinPortal.app.config.security {
    import AuthService = auth.services.AuthService;
    import AuthData = auth.models.AuthData;

    class RouteSecurityInterceptor {
        private readonly forbiddenRedirectState: string = 'signin';

        static $inject = [
            '$rootScope',
            '$injector',
            '$state',
        ];
        constructor(
            private readonly $rootScope: ng.IRootScopeService
            , private readonly $injector: ng.auto.IInjectorService
            , private readonly $state: ng.ui.IStateService
        ) {
        }

        private checkSecurity(event: ng.IAngularEvent, stateSecurity: any, authData: AuthData): void {

            if (!authData.isAuthenticated) {
                this.rejectStateChange(event);

                return;
            }
        }

        private rejectStateChange(event: ng.IAngularEvent): void {
            event.preventDefault();
            this.$state.go(this.forbiddenRedirectState);
        }

        public register(): void {

            this.$rootScope.$on('$stateChangeStart', (event, toState, toParams) => {

                var stateSecurity = toState.data && toState.data.security;
                if (stateSecurity === undefined) {
                    return;
                }

                var authService: AuthService = <AuthService>this.$injector.get('authService');
                this.checkSecurity(event, stateSecurity, authService.authData);
            });
        }
    }

    class RouteSecurityInterceptorActivator {

        static $inject = [
            '$rootScope',
            '$injector',
            '$state',
        ];
        constructor(
            $rootScope: ng.IRootScopeService
            , $injector: ng.auto.IInjectorService
            , $state: ng.ui.IStateService
        ) {
            var interceptor = new RouteSecurityInterceptor($rootScope, $injector, $state);
            interceptor.register();
        }
    }

    angular.module('pinguinPortal').run(RouteSecurityInterceptorActivator);
}
