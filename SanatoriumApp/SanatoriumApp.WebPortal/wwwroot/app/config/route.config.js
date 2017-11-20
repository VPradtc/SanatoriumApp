'use strict';
angular.module('DataAccessApp').config(['$stateProvider', '$urlRouterProvider',
    function ($stateProvider, $urlRouterProvider) {
        $stateProvider
            // App Area
            .state('app', {
                abstract: true,
                template: '<div ui-view></div>',
                resolve: {
                    lazyLoadModule: [
                        '$ocLazyLoad', function ($ocLazyLoad) {
                            return $ocLazyLoad.load('AppModule');
                        }
                    ]
                }
            })

            //Login
            .state('app.auth', {
                abstract: true,
                template: '<div  style="background-color: #fff;" ui-view></div>',
                resolve: {
                    lazyLoadModule: [
                        '$ocLazyLoad', function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['BaseModule', 'userModule', 'AuthModule']);
                        }
                    ]
                }
            })
            .state('app.auth.login', {
                url: '/login',
                controller: 'authController',
                templateUrl: 'app/views/auth/login.html'
            })
            .state('app.auth.register', {
                url: '/register',
                controller: 'registerController',
                templateUrl: 'app/views/auth/register.html'
            })

            .state('app.main.user', {
                url: '/user',
                controller: 'baseController',
                abstract: true,
                template: '<div ui-view> </div>',
                resolve: {
                    lazyLoadModule: [
                        '$ocLazyLoad', function ($ocLazyLoad) {
                            $ocLazyLoad.load('BootstrapUiModule');
                            $ocLazyLoad.load('BaseModule');
                            return $ocLazyLoad.load(['kendoModule', 'userModule']);
                        }
                    ]
                }
            })
            .state('app.main.user.index', {
                url: '/index',
                templateUrl: 'app/views/user/index.html',
                controller: 'userController'
            })
            .state('app.main.user.edit', {
                url: '/edit?id',
                mode: 'edit',
                templateUrl: 'app/views/user/edit.html',
                controller: 'userEditController'
            })
            .state('app.main.user.create', {
                url: '/create',
                mode: 'create',
                templateUrl: 'app/views/user/edit.html',
                controller: 'userEditController'
            })

            .state('app.main.medicalProcedure', {
                url: '/medicalProcedure',
                controller: 'baseController',
                abstract: true,
                template: '<div ui-view> </div>',
                resolve: {
                    lazyLoadModule: [
                        '$ocLazyLoad', function ($ocLazyLoad) {
                            $ocLazyLoad.load('BootstrapUiModule');
                            $ocLazyLoad.load('BaseModule');
                            return $ocLazyLoad.load(['kendoModule', 'medicalProcedureModule']);
                        }
                    ]
                }
            })
            .state('app.main.medicalProcedure.index', {
                url: '/index',
                templateUrl: 'app/views/medicalProcedure/index.html',
                controller: 'medicalProcedureController'
            })
            .state('app.main.medicalProcedure.edit', {
                url: '/edit?id',
                mode: 'edit',
                templateUrl: 'app/views/medicalProcedure/edit.html',
                controller: 'medicalProcedureEditController'
            })
            .state('app.main.medicalProcedure.create', {
                url: '/create',
                mode: 'create',
                templateUrl: 'app/views/medicalProcedure/edit.html',
                controller: 'medicalProcedureEditController'
            })

            .state('app.main.room', {
                url: '/room',
                controller: 'baseController',
                abstract: true,
                template: '<div ui-view> </div>',
                resolve: {
                    lazyLoadModule: [
                        '$ocLazyLoad', function ($ocLazyLoad) {
                            $ocLazyLoad.load('BootstrapUiModule');
                            $ocLazyLoad.load('BaseModule');
                            return $ocLazyLoad.load(['kendoModule', 'roomModule']);
                        }
                    ]
                }
            })
            .state('app.main.room.index', {
                url: '/index',
                templateUrl: 'app/views/room/index.html',
                controller: 'roomController'
            })
            .state('app.main.room.edit', {
                url: '/edit?id',
                mode: 'edit',
                templateUrl: 'app/views/room/edit.html',
                controller: 'roomEditController'
            })
            .state('app.main.room.create', {
                url: '/create',
                mode: 'create',
                templateUrl: 'app/views/room/edit.html',
                controller: 'roomEditController'
            })

            .state('app.main.client', {
                url: '/client',
                controller: 'baseController',
                abstract: true,
                template: '<div ui-view> </div>',
                resolve: {
                    lazyLoadModule: [
                        '$ocLazyLoad', function ($ocLazyLoad) {
                            $ocLazyLoad.load('BootstrapUiModule');
                            $ocLazyLoad.load('BaseModule');
                            return $ocLazyLoad.load(['kendoModule', 'clientModule']);
                        }
                    ]
                }
            })
            .state('app.main.client.index', {
                url: '/index',
                templateUrl: 'app/views/client/index.html',
                controller: 'clientController'
            })
            .state('app.main.client.edit', {
                url: '/edit?id',
                mode: 'edit',
                templateUrl: 'app/views/client/edit.html',
                controller: 'clientEditController'
            })
            .state('app.main.client.create', {
                url: '/create',
                mode: 'create',
                templateUrl: 'app/views/client/edit.html',
                controller: 'clientEditController'
            })


            /// app Main
            .state('app.main', {
                abstract: true,
                authenticate: true,
                templateUrl: 'app/views/main.html',
                resolve: {
                    lazyLoadModule: [
                        '$ocLazyLoad', function ($ocLazyLoad) {
                            $ocLazyLoad.load('AuthModule');
                            $ocLazyLoad.load('loadingModule');
                            $ocLazyLoad.load('dialogModule');
                            return $ocLazyLoad.load(['NavbarModule', 'MainModule'], { serie: true });
                        }
                    ]
                }
            })

            .state('app.main.home', {
                url: '/home',
                controller: 'homeController',
                resolve: {
                    lazyLoadModule: [
                        '$ocLazyLoad', function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['HomeModule']);
                        }
                    ]
                }
            });

        $urlRouterProvider.otherwise('/home');

    }])
 .run(['$rootScope', '$state', 'authService', function ($rootScope, $state, authService) {
     $rootScope['state'] = $state;
     $rootScope['authService'] = authService;

     function $$ParentState(state) {
         // Check if state has explicit parent OR we try guess parent from its name
         var name = state.parent || (/^(.+)\.[^.]+$/.exec(state.name) || [])[1];
         // If we were able to figure out parent name then get this state
         return name && $state.get(name);
     }

     $rootScope.$on('$stateChangeStart', function (event, toState, toParams) {

         for (var state = toState; state && state.name !== ''; state = $$ParentState(state)) {

             if (toState.redirectTo) {
                 event.preventDefault();
                 $state.go(toState.redirectTo, toParams);
             }
         }

         console.log('------------------------- Start --------------------');
         console.log('$stateChangeSuccess ' + ' Date' + new Date().toString());

     });

     $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {

         console.log('$stateChangeSuccess ' + ' Date' + new Date().toString());
     });
     $rootScope
         .$on('$stateChangeError',
             function (event, toState, toParams, fromState, fromParams, error) {
                 console.log('$stateChangeError ' + error.message);
             });
     $rootScope
         .$on('$stateNotFound',
             function (event, toState, toParams, fromState, fromParams) {
                 console.log('$stateNotFound' + ' Date' + Date.now().toString());
             });
     $rootScope
         .$on('$viewContentLoading',
             function (event, viewConfig) {
                 console.log('$viewContentLoading' + ' Date' + new Date().toString());
             });
     $rootScope
         .$on('$viewContentLoaded',
             function (event, viewConfig) {
                 console.log('$viewContentLoaded' + ' Date' + new Date().toString());
                 console.log('------------------------- End --------------------');
             });
 }])