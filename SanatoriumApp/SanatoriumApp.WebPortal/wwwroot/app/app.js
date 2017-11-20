'use strict';

var app = angular.module('DataAccessApp', [
        'oc.lazyLoad',
        'ui.router',
        'ngStorage',
        'ia-loading',
        'ngLocalize',
        'ngLocalize.Config',
        'ngMessages',
        'dndLists',
        'validation.match',
])
    .config([
        '$httpProvider',
        '$locationProvider',
        function ($httpProvider, $locationProvider) {
            $httpProvider.interceptors.push('authInterceptorService');
            $locationProvider.html5Mode(true);
        }
    ])
    .run([
        'authService', function (authService) {
            authService.loadAuthenticationData();
        }
    ]).value('localeConf', {
        basePath: 'app/languages',
        defaultLocale: 'uk',
        fileExtension: '.lang.json',
        observableAttrs: new RegExp('^data-(?!ng-|i18n)'),
        delimiter: '::',
        validTokens: new RegExp('^[\\w\\.-]+\\.[\\w\\s\\.-]+\\w(:.*)?$')
    })
    .value('localeSupported', [
        'uk',
        'en-US',
    ])
    .value('localeFallbacks', {});