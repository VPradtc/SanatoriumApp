'use strict';
angular.module('DataAccessApp').config(['$ocLazyLoadProvider', function ($ocLazyLoadProvider) {
    $ocLazyLoadProvider.config({
        loadedModules: ['DataAccessApp'],
        modules: [
            {
                name: 'AppModule',
                files: [
                    'app/content/css/site.css',
                    "app/content/css/font-awesome.min.css",
                    "app/content/css/animate.min.css",
                    'app/enums/enumRoleIdentifier.js',
                    'app/factory/auth/roleDefinitionProvider.js',
                    'app/directives/topbar/top-menu-directive.js',
                    'app/directives/topbar/content/app-top-menu-content-directive.js',
                ]
            },
            {
                name: 'HomeModule',
                files: [
                    'app/controllers/home/homeController.js',
                ]
            },
            {
                name: 'AuthModule',
                files: [
                    'app/factory/urlBuilder.js',
                    'app/content/css/inspinia/style.css',
                    'app/content/css/login/style.css',
                    'app/controllers/auth/authController.js',
                    'app/controllers/auth/registerController.js',
                    'app/services/baseService.js',
                    'app/services/user/userService.js',
                    'app/factory/auth/homeRouteProvider.js',
                    'app/factory/forms/user/userFormFactory.js',
                    'app/factory/forms/user/registerUserFormFactory.js',
                    'app/services/mobile/mobileService.js',
                ]
            },
            {
                name: 'MainModule',
                files: [
                    'app/content/css/inspinia/style.min.css',
                    'app/scripts/inspinia/inspinia.js',
                    'app/scripts/inspinia/skin.config.min.js',
                    'app/scripts/inspinia/plugins/metisMenu/jquery.metisMenu.js',
                    'app/directives/inspinia-directives.js',

                    'app/services/core/roleSpecificViewLocator.js',
                    'app/directives/core/role-specific-view-directive.js',
                ]
            },
            {
                name: 'NavbarModule',
                files: [
                    'app/directives/navbar/navbar-item-directive.js',
                    'app/directives/navbar/navbar-directive.js',
                    'app/enums/enumRoleIdentifier.js',
                    'app/factory/navbar/navbarFactory.js',
                ]
            },
            { 
                name: 'BaseModule',
                files: [
                    'app/content/css/sweet.min.css',
                    'app/controllers/base/baseController.js',
                    'app/factory/details/detailsStrategyFactory.js',
                    'app/factory/details/strategies/editDetailsStrategy.js',
                    'app/factory/details/strategies/createDetailsStrategy.js',

                    'app/services/baseService.js',

                    'app/directives/common/grid/grid-view-controller.js',

                    'app/directives/common/breadcrumb/breadcrumb-directive.js',
                    'app/directives/common/breadcrumb/breadcrumb-block-directive.js',
                    'app/directives/common/tabs/tabs-directive.js',
                    'app/directives/common/tabs/tab-directive.js',
                    'app/directives/common/grid/tab-grid-view-directive.js',
                    'app/directives/common/form-section-directive.js',
                    'app/directives/common/grid/grid-view-header-buttons-directive.js',
                    'app/directives/common/grid/grid-view-header-title-directive.js',
                    'app/directives/common/grid/grid-view-directive.js',
                    'app/directives/common/grid/grid-directive.js',
                    'app/directives/common/details/details-view-file-upload-directive.js',
                    'app/directives/common/details/details-view-directive.js',
                    'app/directives/common/details/details-header-directive.js',
                    'app/directives/common/controls/edit-control-directive.js',
                    'app/directives/common/controls/input-edit-control-directive.js',
                    'app/directives/common/controls/select/select-edit-control-controller.js',
                    'app/directives/common/controls/select/select-edit-control-directive.js',
                    'app/directives/common/controls/select/combobox-edit-control-directive.js',
                    'app/directives/common/controls/radio-edit-control-directive.js',
                    'app/directives/common/controls/checkbox-edit-control-directive.js',
                    'app/directives/common/controls/header-button-directive.js',
                    'app/directives/common/controls/core/edit-control-validation-block-directive.js',
                    'app/directives/common/controls/core/edit-control-body-directive.js',
                    'app/directives/core/attrs-directive.js',
                    'app/directives/validators/validator-directive.js',

                    'app/factory/forms/common/readonlyFieldDecorator.js',
                    'app/factory/forms/common/indexFieldDecorator.js',
                    'app/factory/forms/common/editControlLocator.js',
                    'app/factory/forms/common/validationConfigFactory.js',
                    'app/factory/forms/common/validationTriggerFactory.js',
                    'app/factory/compositePredicateBuilder.js',
                    'app/factory/urlBuilder.js',
                    'app/factory/collectionCapacityManager.js',
                    'app/factory/buttons/buttonTemplateFactory.js',
                    'app/factory/kendo/dataSourceFactory.js',
                    'app/factory/kendo/grid/dateTime/dateTimeColumnTemplateFactory.js',
                    'app/factory/kendo/grid/dateTime/shortDateColumnTemplateFactory.js',
                    'app/factory/kendo/grid/crudColumnFactory.js',
                    'app/factory/kendo/grid/actionColumnFactory.js',
                    'app/factory/kendo/grid/activateActionFactory.js',
                    'app/factory/kendo/grid/annotateColumnCommand.js',
                    'app/factory/kendo/grid/mapBasicActionColumnCommand.js',
                    'app/factory/kendo/grid/mapCustomActionColumnCommand.js',

                    'app/scripts/jszip/jszip.min.js',

                    'app/scripts/dropzone/dropzone.js',
                    'app/content/css/inspinia/plugins/dropzone/dropzone.css',
                    'app/directives/common/controls/dropzone/dropzone-directive.js',
                    'app/directives/common/controls/dropzone/audio-file-dropzone-directive.js',
                ]
            },
            {
                name: 'iCheckModule',
                files: [
                    'app/scripts/inspinia/plugins/iCheck/icheck.min.js',
                    'app/content/css/inspinia/plugins/iCheck/custom.css'
                ]
            },
            {
                name: 'kendoModule',
                files: [
                    'app/content/css/kendo/kendo.common-material.min.css',
                    'app/content/css/kendo/kendo.custom.css',
                    'app/scripts/kendo/kendo.all.min.js',
                    'app/factory/kendo/dropDownListFactory.js',
                ]
            },
            {
                name: 'dialogModule',
                files: [
                    'app/content/css/ngDialog/ngDialog-theme-default.min.css',
                    'app/content/css/ngDialog/ngDialog.min.css',
                    'app/scripts/ngDialog/ngDialog.min.js',
                    'app/services/dialogs/dialogService.js',
                    'app/controllers/dialogs/dialogController.js',
                    'app/directives/dialogs/dialog-directive.js',
                    'app/directives/dialogs/plain-dialog-directive.js',
                ]
            },
            {
                name: 'MomentJsModule',
                files: [
                    'app/scripts/moment.min.js',
                ]
            },
            {
                name: 'userModule',
                files: [
                    'app/controllers/user/userController.js',
                    'app/controllers/user/userEditController.js',
                    'app/services/user/userService.js',
                    'app/kendo/models/userModel.js',
                    'app/enums/enumRoleIdentifier.js',
                    'app/factory/auth/roleDefinitionProvider.js',
                    'app/factory/forms/user/validators/uniqueEmailValidator.js',
                    'app/factory/forms/user/validators/factory/passwordMatchValidatorFactory.js',
                    'app/factory/forms/user/validators/passwordMatchValidator.js',
                    'app/factory/forms/user/userFormFactory.js',
                    'app/factory/forms/user/detailsUserFormFactory.js',
                ]
            },
            {
                name: 'medicalProcedureModule',
                files: [
                    'app/controllers/medicalProcedure/medicalProcedureController.js',
                    'app/controllers/medicalProcedure/medicalProcedureEditController.js',
                    'app/services/medicalProcedure/medicalProcedureService.js',
                    'app/kendo/models/medicalProcedureModel.js',
                    'app/factory/forms/medicalProcedure/medicalProcedureFormFactory.js',
                ]
            },
            {
                name: 'roomModule',
                files: [
                    'app/enums/enumRoomTypeIdentifier.js',
                    'app/factory/room/roomTypeDefinitionProvider.js',
                    'app/controllers/room/roomController.js',
                    'app/controllers/room/roomEditController.js',
                    'app/services/room/roomService.js',
                    'app/kendo/models/roomModel.js',
                    'app/factory/forms/room/roomFormFactory.js',
                ]
            },
            {
                name: 'clientModule',
                files: [
                    'app/controllers/client/clientController.js',
                    'app/controllers/client/clientEditController.js',
                    'app/services/client/clientService.js',
                    'app/kendo/models/clientModel.js',
                    'app/factory/forms/client/clientFormFactory.js',
                    'app/factory/forms/client/validators/uniquePassportValidator.js',
                ]
            },
            {
                name: 'bookingModule',
                files: [
                    'app/controllers/booking/bookingController.js',
                    'app/controllers/booking/bookingEditController.js',
                    'app/services/booking/bookingService.js',
                    'app/kendo/models/bookingModel.js',
                    'app/factory/forms/booking/bookingFormFactory.js',
                    'app/factory/forms/booking/validators/vacantBookingValidator.js',

                    'app/controllers/booking/procedure/procedureController.js',
                    'app/controllers/booking/procedure/procedureEditController.js',
                    'app/services/booking/procedure/procedureService.js',
                    'app/kendo/models/procedureModel.js',
                    'app/factory/forms/booking/procedure/procedureFormFactory.js',
                ]
            },
            {
                name: 'loadingModule',
                files: [
                    'app/services/loading/loadingService.js',
                ]
            }
        ]
    });
}])