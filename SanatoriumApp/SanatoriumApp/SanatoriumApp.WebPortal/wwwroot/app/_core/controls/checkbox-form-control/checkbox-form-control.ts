module pinguinPortal.app.core.controls {

    import IControlValidation = app.core.validation.IControlValidation;
    import IValidator = app.core.validation.IValidator;

    interface ICheckboxFormControlDirectiveScope extends ng.IScope {
        field: string,
        form: ng.IFormController,
        entity: {},
        validations: IControlValidation[];
    }

    class CheckboxFormControlDirectiveController {
        static $inject = [
            '$scope',
        ];

        private readonly validators: IValidator[] = [];

        constructor(
            private readonly vm: ICheckboxFormControlDirectiveScope
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

    function CheckboxFormControlDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                field: '@',
                entity: '<',
                validations: '<',
            },
            transclude: true,
            templateUrl: 'app/_core/controls/checkbox-form-control/checkbox-form-control.html',
            require: '^^form',
            link: function (scope: ng.IScope, element: JQuery, attrs: ng.IAttributes, ngFormController: ng.IFormController): void {
                scope.form = ngFormController;
            },
            controller: CheckboxFormControlDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixCheckboxFormControl', CheckboxFormControlDirective);
}
