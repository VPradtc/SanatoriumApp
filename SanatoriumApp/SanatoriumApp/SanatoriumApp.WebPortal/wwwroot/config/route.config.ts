module pinguinPortal.app.config {

    class RouteConfig {
        static $inject = [
            '$stateProvider',
            '$urlRouterProvider',
        ];

        constructor(
            $stateProvider: angular.ui.IStateProvider
            , $urlRouterProvider: angular.ui.IUrlRouterProvider
        ) {
            $urlRouterProvider.otherwise('/');

            $stateProvider
                .state('app', {
                    url: '/',
                    templateUrl: 'app/app.html',
                    resolve: {
                        appModule: [
                            '$ocLazyLoad', ($ocLazyLoad: oc.ILazyLoad) => {
                                return $ocLazyLoad.load(['CoreModule', 'AppModule'], { serie: true });
                            },
                        ],
                    },
                    data: {
                        security: {}
                    },
                })

                .state('app.home', {
                    url: 'home',
                    template: '<ix-home-view></ix-home-view>',
                    resolve: {
                        homeModule: [
                            '$ocLazyLoad',
                            'appModule',
                            ($ocLazyLoad: oc.ILazyLoad) => {
                                return $ocLazyLoad.load(['HomeModule'], { serie: true });
                            },
                        ],
                    },
                    data: {
                        security: {}
                    },
                });
        }
    }

    angular.module('pinguinPortal').config(RouteConfig);
}
