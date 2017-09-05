/// <autosync enabled="true" />
/// <reference path="../wwwroot/app/app.js" />
/// <reference path="../wwwroot/app/config/lazyLoad.config.js" />
/// <reference path="../wwwroot/app/config/route.config.js" />
/// <reference path="../wwwroot/app/config/url.debug.config.js" />
/// <reference path="../wwwroot/app/config/url.publish.config.js" />
/// <reference path="../wwwroot/app/controllers/auth/authController.js" />
/// <reference path="../wwwroot/app/controllers/auth/registerController.js" />
/// <reference path="../wwwroot/app/controllers/base/baseController.js" />
/// <reference path="../wwwroot/app/controllers/dialogs/dialogController.js" />
/// <reference path="../wwwroot/app/controllers/home/homeController.js" />
/// <reference path="../wwwroot/app/controllers/user/userController.js" />
/// <reference path="../wwwroot/app/controllers/user/userEditController.js" />
/// <reference path="../wwwroot/app/directives/inspinia-directives.js" />
/// <reference path="../wwwroot/app/directives/star-rating-directive.js" />
/// <reference path="../wwwroot/app/directives/switcher-directive.js" />
/// <reference path="../wwwroot/app/directives/common/breadcrumb-directive.js" />
/// <reference path="../wwwroot/app/directives/common/details-view-directive.js" />
/// <reference path="../wwwroot/app/directives/common/form-section-directive.js" />
/// <reference path="../wwwroot/app/directives/common/breadcrumb/breadcrumb-block-directive.js" />
/// <reference path="../wwwroot/app/directives/common/breadcrumb/breadcrumb-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/checkbox-edit-control-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/edit-control-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/header-button-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/input-edit-control-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/radio-edit-control-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/select-edit-control-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/core/edit-control-body-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/core/edit-control-validation-block-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/dropzone/audio-file-dropzone-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/dropzone/dropzone-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/select/combobox-edit-control-directive.js" />
/// <reference path="../wwwroot/app/directives/common/controls/select/select-edit-control-controller.js" />
/// <reference path="../wwwroot/app/directives/common/controls/select/select-edit-control-directive.js" />
/// <reference path="../wwwroot/app/directives/common/details/details-header-directive.js" />
/// <reference path="../wwwroot/app/directives/common/details/details-view-directive.js" />
/// <reference path="../wwwroot/app/directives/common/details/details-view-file-upload-directive.js" />
/// <reference path="../wwwroot/app/directives/common/grid/grid-directive.js" />
/// <reference path="../wwwroot/app/directives/common/grid/grid-view-controller.js" />
/// <reference path="../wwwroot/app/directives/common/grid/grid-view-directive.js" />
/// <reference path="../wwwroot/app/directives/common/grid/grid-view-header-buttons-directive.js" />
/// <reference path="../wwwroot/app/directives/common/grid/grid-view-header-title-directive.js" />
/// <reference path="../wwwroot/app/directives/common/grid/tab-grid-view-directive.js" />
/// <reference path="../wwwroot/app/directives/common/tabs/tab-directive.js" />
/// <reference path="../wwwroot/app/directives/common/tabs/tabs-directive.js" />
/// <reference path="../wwwroot/app/directives/core/attrs-directive.js" />
/// <reference path="../wwwroot/app/directives/core/role-specific-view-directive.js" />
/// <reference path="../wwwroot/app/directives/dialogs/dialog-directive.js" />
/// <reference path="../wwwroot/app/directives/dialogs/plain-dialog-directive.js" />
/// <reference path="../wwwroot/app/directives/navbar/navbar-directive.js" />
/// <reference path="../wwwroot/app/directives/navbar/navbar-item-directive.js" />
/// <reference path="../wwwroot/app/directives/topbar/top-menu-directive.js" />
/// <reference path="../wwwroot/app/directives/topbar/content/app-top-menu-content-directive.js" />
/// <reference path="../wwwroot/app/directives/validators/async-validator-directive.js" />
/// <reference path="../wwwroot/app/directives/validators/validator-directive.js" />
/// <reference path="../wwwroot/app/enums/enumRoleIdentifier.js" />
/// <reference path="../wwwroot/app/factory/collectionCapacityManager.js" />
/// <reference path="../wwwroot/app/factory/compositePredicateBuilder.js" />
/// <reference path="../wwwroot/app/factory/promiseFactory.js" />
/// <reference path="../wwwroot/app/factory/roleDefinitionProvider.js" />
/// <reference path="../wwwroot/app/factory/urlBuilder.js" />
/// <reference path="../wwwroot/app/factory/auth/homeRouteProvider.js" />
/// <reference path="../wwwroot/app/factory/auth/roleDefinitionProvider.js" />
/// <reference path="../wwwroot/app/factory/buttons/buttonTemplateFactory.js" />
/// <reference path="../wwwroot/app/factory/details/detailsStrategyFactory.js" />
/// <reference path="../wwwroot/app/factory/details/strategies/createDetailsStrategy.js" />
/// <reference path="../wwwroot/app/factory/details/strategies/editDetailsStrategy.js" />
/// <reference path="../wwwroot/app/factory/forms/common/editControlLocator.js" />
/// <reference path="../wwwroot/app/factory/forms/common/indexFieldDecorator.js" />
/// <reference path="../wwwroot/app/factory/forms/common/readonlyFieldDecorator.js" />
/// <reference path="../wwwroot/app/factory/forms/common/validationConfigFactory.js" />
/// <reference path="../wwwroot/app/factory/forms/common/validationTriggerFactory.js" />
/// <reference path="../wwwroot/app/factory/forms/user/detailsUserFormFactory.js" />
/// <reference path="../wwwroot/app/factory/forms/user/registerUserFormFactory.js" />
/// <reference path="../wwwroot/app/factory/forms/user/userFormFactory.js" />
/// <reference path="../wwwroot/app/factory/forms/user/validators/passwordMatchValidator.js" />
/// <reference path="../wwwroot/app/factory/forms/user/validators/uniqueEmailValidator.js" />
/// <reference path="../wwwroot/app/factory/forms/user/validators/factory/passwordMatchValidatorFactory.js" />
/// <reference path="../wwwroot/app/factory/kendo/dataSourceFactory.js" />
/// <reference path="../wwwroot/app/factory/kendo/dropDownListFactory.js" />
/// <reference path="../wwwroot/app/factory/kendo/grid/actionColumnFactory.js" />
/// <reference path="../wwwroot/app/factory/kendo/grid/activateActionFactory.js" />
/// <reference path="../wwwroot/app/factory/kendo/grid/annotateColumnCommand.js" />
/// <reference path="../wwwroot/app/factory/kendo/grid/crudColumnFactory.js" />
/// <reference path="../wwwroot/app/factory/kendo/grid/mapBasicActionColumnCommand.js" />
/// <reference path="../wwwroot/app/factory/kendo/grid/mapCustomActionColumnCommand.js" />
/// <reference path="../wwwroot/app/factory/kendo/grid/dateTime/dateTimeColumnTemplateFactory.js" />
/// <reference path="../wwwroot/app/factory/kendo/grid/dateTime/shortDateColumnTemplateFactory.js" />
/// <reference path="../wwwroot/app/factory/navbar/navbarFactory.js" />
/// <reference path="../wwwroot/app/kendo/models/userModel.js" />
/// <reference path="../wwwroot/app/scripts/angular-local-storage.js" />
/// <reference path="../wwwroot/app/scripts/angular-ui-router.js" />
/// <reference path="../wwwroot/app/scripts/angular.js" />
/// <reference path="../wwwroot/app/scripts/card.js" />
/// <reference path="../wwwroot/app/scripts/jquery.min.js" />
/// <reference path="../wwwroot/app/scripts/loader.js" />
/// <reference path="../wwwroot/app/scripts/moment.min.js" />
/// <reference path="../wwwroot/app/scripts/ng-virtual-keyboard.js" />
/// <reference path="../wwwroot/app/scripts/ngStorage.min.js" />
/// <reference path="../wwwroot/app/scripts/ocLazyLoad.min.js" />
/// <reference path="../wwwroot/app/scripts/select.js" />
/// <reference path="../wwwroot/app/scripts/ui-bootstrap-tpls-0.12.0.min.js" />
/// <reference path="../wwwroot/app/scripts/angular-cookies/angular-cookies.js" />
/// <reference path="../wwwroot/app/scripts/angular-drag-and-drop-lists/angular-drag-and-drop-lists.js" />
/// <reference path="../wwwroot/app/scripts/angular-localization/angular-localization.js" />
/// <reference path="../wwwroot/app/scripts/angular-messages/angular-messages.js" />
/// <reference path="../wwwroot/app/scripts/angular-sanitize/angular-sanitize.js" />
/// <reference path="../wwwroot/app/scripts/angular-validation-match/angular-validation-match.js" />
/// <reference path="../wwwroot/app/scripts/dropzone/dropzone.js" />
/// <reference path="../wwwroot/app/scripts/extensions/stringExtensions.js" />
/// <reference path="../wwwroot/app/scripts/fileupload/FileAPI.js" />
/// <reference path="../wwwroot/app/scripts/fileupload/ng-file-upload-all.js" />
/// <reference path="../wwwroot/app/scripts/fileupload/ng-file-upload-shim.js" />
/// <reference path="../wwwroot/app/scripts/fileupload/ng-file-upload.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/inspinia.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/skin.config.min.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/angular-notify/angular-notify.min.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/blueimp/jquery.blueimp-gallery.min.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/chartJs/angles.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/chartJs/Chart.min.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/datapicker/angular-datepicker.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/dataTables/dataTables.bootstrap.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/dataTables/dataTables.responsive.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/dataTables/jquery.dataTables.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/iCheck/icheck.min.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/metisMenu/jquery.metisMenu.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/summernote/angular-summernote.min.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/summernote/summernote.min.js" />
/// <reference path="../wwwroot/app/scripts/inspinia/plugins/toastr/toastr.min.js" />
/// <reference path="../wwwroot/app/scripts/jszip/jszip.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/kendo.all.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-029.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-AU.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-BZ.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-CA.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-GB.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-HK.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-IE.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-IN.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-JM.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-MY.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-NZ.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-PH.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-SG.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-TT.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-US.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-ZA.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en-ZW.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.en.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.ru-RU.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.ru-UA.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.ru.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.uk-UA.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/cultures/kendo.culture.uk.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/messages/kendo.messages.en-US.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/messages/kendo.messages.ru-RU.min.js" />
/// <reference path="../wwwroot/app/scripts/kendo/messages/kendo.messages.uk-UA.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-all.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-altkeyspopup.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-autocomplete.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-caret.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-extender.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-mobile.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-navigation.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-previewkeyset.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-scramble.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.extension-typing.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.keyboard.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/js/jquery.mousewheel.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/layouts/keyboard-layouts-combined.min.js" />
/// <reference path="../wwwroot/app/scripts/keyboard/layouts/keyboard-layouts-greywyvern.min.js" />
/// <reference path="../wwwroot/app/scripts/mobile-detect/mobile-detect.js" />
/// <reference path="../wwwroot/app/scripts/ngDialog/ngDialog.min.js" />
/// <reference path="../wwwroot/app/services/authInterceptorService.js" />
/// <reference path="../wwwroot/app/services/authService.js" />
/// <reference path="../wwwroot/app/services/baseService.js" />
/// <reference path="../wwwroot/app/services/dialogService.js" />
/// <reference path="../wwwroot/app/services/userService.js" />
/// <reference path="../wwwroot/app/services/core/roleSpecificViewLocator.js" />
/// <reference path="../wwwroot/app/services/dialogs/dialogService.js" />
/// <reference path="../wwwroot/app/services/loading/loadingService.js" />
/// <reference path="../wwwroot/app/services/mobile/mobileService.js" />
/// <reference path="../wwwroot/app/services/user/userService.js" />
