module pinguinPortal.app.core.controls {

    import IControlValidation = app.core.validation.IControlValidation;
    import IValidator = app.core.validation.IValidator;

    interface IDatePickerFormControlDirectiveScope extends ng.IScope {
        type: string,
        label: string,
        field: string,
        form: ng.IFormController,
        entity: any,
        validations: IControlValidation[];
    }

    class DatePickerFormControlDirectiveController {
        static $inject = [
            '$scope',
        ];

        private readonly validators: IValidator[] = [];

        constructor(
            private readonly vm: IDatePickerFormControlDirectiveScope
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

    function DatePickerFormControlDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                type: '@',
                label: '<',
                field: '@',
                entity: '<',
                validations: '<',
            },
            templateUrl: 'app/_core/controls/date-picker-form-control/date-picker-form-control.html',
            require: '^^form',
            link: function (scope: ng.IScope, element: JQuery, attrs: ng.IAttributes, ngFormController: ng.IFormController): void {
                scope.form = ngFormController;
            },
            controller: DatePickerFormControlDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixDatePickerFormControl', DatePickerFormControlDirective);
}
