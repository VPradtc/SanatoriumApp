module pinguinPortal.app.core.controls {

    import IControlValidation = app.core.validation.IControlValidation;
    import IValidator = app.core.validation.IValidator;

    interface IFormControlDirectiveScope extends ng.IScope {
        validations: IControlValidation[];
    }

    class FormControlDirectiveController {
        static $inject = [
            '$scope',
        ];

        private readonly validators: IValidator[] = [];

        constructor(
            private readonly vm: IFormControlDirectiveScope
        ) {
            this.vm.showLabel = this.vm.showLabel !== undefined && this.vm.showLabel; // false by default
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

    function FormControlDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                type: '@',
                label: '<',
                field: '@',
                entity: '<',
                validations: '<',
                showLabel: '<',
            },
            templateUrl: 'app/_core/controls/form-control/form-control.html',
            require: '^^form',
            link: function (scope: ng.IScope, element: JQuery, attrs: ng.IAttributes, ngFormController: ng.IFormController): void {
                scope.form = ngFormController;
            },
            controller: FormControlDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixFormControl', FormControlDirective);
}
