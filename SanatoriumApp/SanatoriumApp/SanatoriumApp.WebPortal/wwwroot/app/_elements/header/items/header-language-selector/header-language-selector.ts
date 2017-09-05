module pinguinPortal.app.header.items {

    import CustomEvents = app.config.CustomEvents;

    interface ILanguageBinding {
        locale: string,
        label: string,
    }

    class HeaderLanguageSelectorDirectiveController {
        static $inject = [
            '$scope',
            'locale',
            '$rootScope'
        ];

        public model: { selectedLanguage: ILanguageBinding };

        public readonly languages: ILanguageBinding[] = [
            {
                label: 'English',
                locale: 'en-US',
            },
            {
                label: 'French',
                locale: 'fr-FR',
            },
        ];

        constructor(
            private readonly vm: ng.IScope
            , private readonly localeService: any
            , private readonly $rootScope: ng.IRootScopeService
        ) {
            vm.selectLanguage = this.selectLanguage.bind(this);
            vm.getLanguageItemClass = this.getLanguageItemClass.bind(this);

            this.model = { selectedLanguage: this.languages[0] };
            this.initSelectedLanguage();

            vm.languages = this.languages;
        }

        private initSelectedLanguage(): void {
            var selectedLocale = this.localeService.getLocale();
            var selectedLanguage = this.languages.filter(l => l.locale === selectedLocale)[0];

            this.model.selectedLanguage = selectedLanguage;
        }

        public selectLanguage(languageBinding: ILanguageBinding): void | ILanguageBinding {
            if (languageBinding === undefined) {
                return this.model.selectedLanguage;
            }

            this.localeService.setLocale(languageBinding.locale);

            this.$rootScope.$broadcast(CustomEvents.headerLanguageSelected, languageBinding.locale);

            this.initSelectedLanguage();
        }

        public getLanguageItemClass(language: ILanguageBinding): string {
            return this.model.selectedLanguage === language
                ? 'selected'
                : '';
        }
    }

    function HeaderLanguageSelectorDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
            },
            templateUrl: 'app/_elements/header/items/header-language-selector/header-language-selector.html',
            controller: HeaderLanguageSelectorDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixHeaderLanguageSelector', HeaderLanguageSelectorDirective);
}
