module pinguinPortal.app.config {
    import RouteHistoryService = pinguinPortal.app.services.RouteHistoryService;

    class RouteEventsConfig {
        static $inject = [
            '$rootScope',
            'routeHistoryService',
        ];

        constructor(
            $rootScope: angular.IRootScopeService
            , routeHistoryService: RouteHistoryService
        ) {

            $rootScope.$on('$stateChangeStart', (
                event: ng.IAngularEvent
                , toState: ng.ui.IState
                , toParams: any
            ) => {
                console.log('------------------------- Start --------------------');
                console.log('$stateChangeStart ' + ' Date' + new Date().toString());
            });

            $rootScope.$on('$stateChangeSuccess', (
                event: ng.IAngularEvent
                , toState: ng.ui.IState
                , toParams: any
                , fromState: ng.ui.IState
                , fromParams: any
            ) => {
                console.log('$stateChangeSuccess ' + ' Date' + new Date().toString());
                routeHistoryService.setPreviousState(fromState, fromParams);
            });

            $rootScope
                .$on('$stateChangeError', (
                    event: ng.IAngularEvent
                    , toState: ng.ui.IState
                    , toParams: any
                    , fromState: ng.ui.IState
                    , fromParams: any
                    , error
                ) => {
                    console.log('$stateChangeError ' + error.message);
                });
            $rootScope
                .$on('$stateNotFound', (
                    event: ng.IAngularEvent
                    , toState: ng.ui.IState
                    , toParams: any
                    , fromState: ng.ui.IState
                    , fromParams: any
                ) => {
                    console.log('$stateNotFound' + ' Date' + Date.now().toString());
                });

            $rootScope
                .$on('$viewContentLoading', (
                    event: ng.IAngularEvent
                    , viewConfig
                ) => {
                    console.log('$viewContentLoading' + ' Date' + new Date().toString());
                });

            $rootScope
                .$on('$viewContentLoaded', (
                    event: ng.IAngularEvent
                    , viewConfig
                ) => {
                    console.log('$viewContentLoaded' + ' Date' + new Date().toString());
                    console.log('------------------------- End --------------------');
                });
        }
    }

    angular.module('pinguinPortal').run(RouteEventsConfig);
}