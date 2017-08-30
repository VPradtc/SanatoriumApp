module pinguinPortal.app.config {
    class LazyLoadConfig implements oc.IProviderConfig {
        static $inject = ['$ocLazyLoadProvider'];

        constructor(
            $ocLazyLoadProvider: oc.ILazyLoadProvider
        ) {
            $ocLazyLoadProvider.config(this);
        }

        asyncLoader: any = null;
        loadedModules: string[] = [
            'pinguinPortal'
        ];

        modules: oc.IModuleConfig[] = [
            {
                name: 'AppModule',
                files: [
                    'content/css/site.css',

                    'app/_core/models/localization/localizationObservable.js',
                    'app/_core/models/enums/languageIdentifier.js',
                    'app/_services/localizationService.js',
                    'app/_services/companyInfoService.js',
                    'app/_services/accountService.js',
                    'app/_directives/restrict-role/restrict-role.js',

                    'app/_elements/header/app-header.js',

                    'app/_elements/header/items/header-language-selector/header-language-selector.js',

                    'app/_elements/footer/app-footer.js',

                    'app/_elements/sidebar/items/app-sidebar-item.js',
                    'app/_elements/sidebar/app-sidebar.js',
                ],
            },
            {
                name: 'CoreModule',
                files: [
                    'app/_core/controls/grid-control/grid-page-size-constant.js',
                    'app/_core/controls/grid-control/order-by-icon/order-by-icon.js',

                    'app/_core/models/observable/observable.js',
                    'app/_core/models/enums/companyTypeIdentifier.js',
                    'app/_core/models/enums/privilegeIdentifier.js',
                    'app/_core/models/enums/fieldTypesIdentifier.js',
                    'app/_core/models/enums/enumExtension.js',
                    'app/_core/models/enums/documentTypeIdentifier.js',

                    'app/_core/validation/ivalidator.js',
                    'app/_core/validation/asyncValidator.js',
                    'app/_core/validation/syncValidator.js',
                    'app/_core/validation/requiredValidator.js',
                    'app/_core/validation/equalsValidator.js',
                    'app/_core/validation/fieldLengthValidator.js',
                    'app/_core/validation/iControlValidation.js',
                    'app/_core/validation/directives/validators-directive.js',
                    'app/_core/controls/form-control/form-control-validation-block/form-control-validation-block.js',
                    'app/_core/controls/form-control/form-control.js',
                    'app/_core/controls/date-picker-form-control/date-picker-form-control.js',
                    'app/_core/controls/phone-number-form-control/phone-number-form-control.js',
                    'app/_core/controls/checkbox-form-control/checkbox-form-control.js',
                    'app/_core/controls/multi-select-form-control/multi-select-form-control.js',
                    'app/_core/controls/ago-date-label-control/ago-date-label-control.js',
                    'app/_core/controls/pagination/paginationConfigModel.js',
                    'app/_core/controls/pagination/pagination-control.js',
                    'app/_core/controls/grid-control/grid-control.js',
                    'app/_core/controls/grid-control/gridFieldConfigModel.js',
                    'app/_core/controls/autocomplete-control/autocomplete-control.js',
                    'app/_core/controls/text-area-form-control/text-area-form-control.js',
                    'app/_core/controls/integer-form-control/integer-form-control.js',
                    'app/_core/controls/decimal-form-control/decimal-form-control.js',

                    'app/_core/controls/file-form-control/directives/file-model.js',
                    'app/_core/controls/file-form-control/file-form-control.js',
                    'app/_core/http/urlBuilder.js',
                    'app/_core/http/baseHttpService.js',

                    'app/_core/filters/infoSizeConverter.js',
                    'app/_core/filters/tailFilter.js',
                    'app/_core/attributes/attrs-directive.js',

                    'app/myCatalogs/_services/catalogService.js',

                    'app/_constants/appConstants.js',

                ],
            },
            {
                name: 'DialogModule',
                files: [
                    'content/css/dialog/dialog.css',
                    'app/dialog/dialogService.js',
                    'app/dialog/_elements/dialog-view.js',
                ]
            },
            {
                name: 'HomeModule',
                files: [
                    'app/home/_services/homeRouteProvider.js',

                    'app/home/home-view.js',
                ],
            },
        ];
    }

    angular.module('pinguinPortal').config(LazyLoadConfig);
}
