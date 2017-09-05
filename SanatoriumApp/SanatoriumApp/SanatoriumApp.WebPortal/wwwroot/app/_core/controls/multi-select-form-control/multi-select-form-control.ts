module pinguinPortal.app.core.controls {

    import IControlValidation = app.core.validation.IControlValidation;
    import IValidator = app.core.validation.IValidator;

    import IDropdownModel = app.models.IDropdownModel;

    interface IMultiSelectFormControlDirectiveScope extends ng.IScope {
        field: string,
        form: ng.IFormController,
        entity: {},
        validations: IControlValidation[];
        findItemsAction: (viewValue: string) => IDropdownModel[];
    }

    class MultiSelectFormControlDirectiveController {
        static $inject = [
            '$scope',
        ];

        private readonly validators: IValidator[] = [];

        private lastGeneratedId = 0;

        constructor(
            private readonly vm: IMultiSelectFormControlDirectiveScope
        ) {
            this.vm.createValidators = this.createValidators.bind(this);
            this.vm.assignId = this.assignId.bind(this);
        }

        public createValidators(): IValidator[] {
            if (this.vm.validations === undefined) {
                return [];
            }

            this.validators.length = 0;

            this.vm.validations.forEach(validation => this.validators.push(validation.validator));

            return this.validators;
        }

        public assignId(tag: IDropdownModel): void {
            if (tag.id !== undefined) {
                return;
            }

            this.lastGeneratedId--;

            tag.id = this.lastGeneratedId;
        }
    }

    function MultiSelectFormControlDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                label: '@',
                field: '@',
                entity: '<',
                validations: '<',
                findItemsAction: '<',
            },
            templateUrl: 'app/_core/controls/multi-select-form-control/multi-select-form-control.html',
            require: '^^form',
            link: function (scope: ng.IScope, element: JQuery, attrs: ng.IAttributes, ngFormController: ng.IFormController): void {
                scope.form = ngFormController;
            },
            controller: MultiSelectFormControlDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixMultiSelectFormControl', MultiSelectFormControlDirective);
}
