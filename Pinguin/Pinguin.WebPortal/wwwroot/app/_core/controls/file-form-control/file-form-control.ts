module pinguinPortal.app.core.controls {

    import IControlValidation = app.core.validation.IControlValidation;
    import IValidator = app.core.validation.IValidator;

    interface IFileFormControlDirectiveScope extends ng.IScope {
        validations: IControlValidation[];
    }

    class FileFormControlDirectiveController {
        static $inject = [
            '$scope',
        ];

        private readonly validators: IValidator[] = [];

        constructor(
            private readonly vm: IFileFormControlDirectiveScope
        ) {
            this.vm.createValidators = this.createValidators.bind(this);
        }

        public createValidators(): IValidator[] {
            if (this.vm.validations === undefined) {
                return [];
            }

            this.validators.length = 0;

            this.vm.validations.forEach(validation => this.validators.push(validation.validator));

            return this.validators;
        }
    }

    function FileFormControlDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                label: '<',
                field: '@',
                entity: '<',
                validations: '<',
                extensions: '@',
            },
            templateUrl: 'app/_core/controls/file-form-control/file-form-control.html',
            require: '^^form',
            link: function (scope: ng.IScope, element: JQuery, attrs: ng.IAttributes, ngFormController: ng.IFormController): void {
                scope.form = ngFormController;
            },
            controller: FileFormControlDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixFileFormControl', FileFormControlDirective);
}
