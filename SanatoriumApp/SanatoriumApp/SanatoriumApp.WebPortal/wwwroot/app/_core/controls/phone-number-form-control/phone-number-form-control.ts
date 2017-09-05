module pinguinPortal.app.core.controls {

    import IControlValidation = app.core.validation.IControlValidation;
    import IValidator = app.core.validation.IValidator;

    class StubPhoneNumberValidator implements IValidator {

        public name: string = 'ngIntlTelInput';
        public attach(controller: ng.INgModelController): void {
            return void 0;
        }
    }

    interface IPhoneNumberFormControlScope extends ng.IScope {
        rawValidations: IControlValidation[],
    }

    class PhoneNumberFormControlDirectiveController {
        static $inject = [
            '$scope',
        ];

        private readonly validators: IValidator[] = [];
        private readonly validations: IControlValidation[] = [];

        private readonly phoneNumberValidationStub: IControlValidation = {
            message: 'signin.invalidPhoneNumber',
            validator: new StubPhoneNumberValidator(),
        };

        constructor(
            private readonly vm: IPhoneNumberFormControlScope
        ) {
            this.vm.createValidators = this.createValidators.bind(this);

            vm.$watch('rawValidations', () => this.createValidations());
        }

        private createValidations(): void {
            this.validations.splice(0, this.validations.length);

            this.vm.rawValidations.forEach(v => this.validations.push(v));

            this.validations.push(this.phoneNumberValidationStub);
            this.vm.validations = this.validations;
        }

        public createValidators(): IValidator[] {
            if (this.vm.rawValidations === undefined) {
                return [];
            }

            this.validators.length = 0;

            this.vm.rawValidations.forEach(validation => this.validators.push(validation.validator));

            return this.validators;
        }

    }

    function PhoneNumberFormControlDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                label: '<',
                field: '@',
                entity: '<',
                rawValidations: '<validations',
            },
            templateUrl: 'app/_core/controls/phone-number-form-control/phone-number-form-control.html',
            require: '^^form',
            link: function (scope: ng.IScope, element: JQuery, attrs: ng.IAttributes, ngFormController: ng.IFormController): void {
                scope.form = ngFormController;
            },
            controller: PhoneNumberFormControlDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixPhoneNumberFormControl', PhoneNumberFormControlDirective);
}
