module pinguin.app {

    class AppConfig {
        static $inject = [
            '$locationProvider',
        ];
        constructor($locationProvider: ng.ILocationProvider) {
            $locationProvider.html5Mode(true);
        }
    }

    class LocaleConfig {
        static localeConf: any = {
            basePath: 'languages',
            defaultLocale: 'en-US',
            fileExtension: '.lang.json',
            observableAttrs: new RegExp('^data-(?!ng-|i18n)'),
            delimiter: '::',
            validTokens: new RegExp('^[\\w\\.-]+\\.[\\w\\s\\.-]+\\w(:.*)?$'),
            persistSelection: true,
            cookieName: 'selectedLocale',
        };

        static localeSupported: string[] = [
            'en-US',
        ];

        static localeFallbacks: any = {
        };
    }

    angular.module('pinguinPortal', [
        'ui.router',
        'oc.lazyLoad',
        'ngSanitize',
        'ngCookies',
        'ngLocalize',
        'ngLocalize.Config',
        'ngLocalize.Events',
        'ngStorage',
        'ngMessages',
        'ngDialog',
        'dndLists',
    ])
        .config(AppConfig)

        .value('localeConf', LocaleConfig.localeConf)
        .value('localeSupported', LocaleConfig.localeSupported)
        .value('localeFallbacks', LocaleConfig.localeFallbacks)
        ;
}
