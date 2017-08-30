module pinguinPortal.app.services {

    import LocalizationObservable = app.core.models.localization.LocalizationObservable;

    import UrlSettings = app.config.UrlSettings;

    import LanguageIdentifier = app.core.models.enums.LanguageIdentifier;
    import ILanguage = app.core.models.entities.ILanguage;
    import BaseHttpService = app.core.http.BaseHttpService;

    import CustomEvents = app.config.CustomEvents;

    export class LocalizationService extends LocalizationObservable {
        static $inject = [
            '$rootScope',
            '$filter',
            'locale',
            'baseHttpService',
            '$q'
        ];

        private currentLanguageId: LanguageIdentifier;
        private currentLanguageIdPromise: ng.IPromise<LanguageIdentifier>;

        private supportedLanguages: Array<ILanguage>;

        constructor(
            private readonly $rootScope: ng.IRootScopeService
            , private readonly $filter: ng.IFilterService
            , private readonly locale: any
            , private readonly baseHttpService: BaseHttpService
            , $q: ng.IQService) {

            super($q);

            this.currentLanguageIdPromise = this.getSupportedLanguagesMock()
                .then(response => {
                    this.supportedLanguages = response;
                    this.currentLanguageId = this.getByName(this.locale.getLocale());

                    return this.currentLanguageId;
                });

            this.currentLanguageIdPromise.then(currentLanguageId =>
                this.$rootScope.$on(CustomEvents.headerLanguageSelected,
                    (event, newLocale: string) => {
                        this.currentLanguageId = this.getByName(newLocale);
                        this.notify();
                    })
            );
        }

        public getCurrentLanguage(): ng.IPromise<LanguageIdentifier> {
            return this.currentLanguageId !== undefined
                ? this.$q.when(this.currentLanguageId)
                : this.currentLanguageIdPromise;
        }

        public getByIdentifier(locale: LanguageIdentifier): string {
            var result = this.$filter('filter')(this.supportedLanguages, { id: locale });

            return (result && result[0])
                ? this.$filter('filter')(this.supportedLanguages, { id: locale })[0].localeName
                : '';
        }

        public getByName(localeName: string): LanguageIdentifier {
            let result = this.$filter('filter')(this.supportedLanguages, { localeName: localeName });

            return (result && result[0])
                ? this.$filter('filter')(this.supportedLanguages, { localeName: localeName })[0].id
                : -1;
        }

        public getSupportedLanguages(): ng.IPromise<Array<ILanguage>> {
            return this.baseHttpService.get(UrlSettings.serverApiUri + '/api/catalog/GetSupportedLanguages');
        }

        public getLocalizationOptions(): ng.IPromise<Array<ILanguage>> {
            return (this.supportedLanguages !== null)
                ? this.$q.when(this.supportedLanguages.filter(x => x.id !== this.currentLanguageId))
                : this.getSupportedLanguages().then(response => response.filter(x => x.id !== this.currentLanguageId));

        }

        protected loadCurrentLanguage(): ng.IPromise<LanguageIdentifier> {
            return this.getCurrentLanguage();
        }

        private getSupportedLanguagesMock(): ng.IPromise<Array<ILanguage>> {
            var result: Array<ILanguage> = [
                {
                    id: 1,
                    localeName: 'en-US',
                    name: 'English(US)'
                },
                {
                    id: 2,
                    localeName: 'fr-FR',
                    name: 'French'
                },
            ];

            return this.$q.when(result);
        }
    }

    angular.module('pinguinPortal').service('localizationService', LocalizationService);
}
