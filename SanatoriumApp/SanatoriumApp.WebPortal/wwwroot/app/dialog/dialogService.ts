module pinguinPortal.app.dialog {

    export interface IDialogDictionary {
        prompt: ng.dialog.IDialogOpenOptions;
    }

    export interface IConfirmationDialogData {
        title?: string;
        name?: string;
    }

    export class DialogService {
        static $inject = [
            'ngDialog'
        ];

        private readonly dialogs: IDialogDictionary;

        constructor(
            private readonly ngDialog: ng.dialog.IDialogService) {
        }

        public showConfirmationDialog(
            data?: IConfirmationDialogData
            , preCloseCallback?: any
            , config?: ng.dialog.IDialogOpenOptions
        ): ng.IPromise<any> {

            var basicConfig: ng.dialog.IDialogOpenConfirmOptions = {
                template: 'app/dialog/_views/plain-prompt-dialog-view.html',
                data: data,
                preCloseCallback: preCloseCallback,
            };

            var combinedConfig = angular.merge({}, basicConfig, config);

            return this.ngDialog.openConfirm(combinedConfig);
        }

        public showCustomDialog(config?: ng.dialog.IDialogOpenOptions): ng.IPromise<any> {
            var basicConfig: ng.dialog.IDialogOpenConfirmOptions = {
                template: 'app/dialog/_views/plain-prompt-dialog-view.html',
            };

            var combinedConfig = angular.merge({}, basicConfig, config);

            return this.ngDialog.openConfirm(combinedConfig);
        }
    }

    angular.module('pinguinPortal').service('dialogService', DialogService);
}
