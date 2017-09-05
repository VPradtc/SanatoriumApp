module pinguinPortal.app.core.controls {

    import IControlValidation = app.core.validation.IControlValidation;

    interface IFormControlValidationBlockDirectiveScope extends ng.IScope {
        validations: IControlValidation[];
        field: string;
        form: ng.IFormController
    }

    class FormControlValidationBlockDirectiveController {
        static $inject = [
            '$scope',
        ];

        constructor(
            private readonly vm: IFormControlValidationBlockDirectiveScope
        ) {
        }
    }

    function FormControlValidationBlockDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                field: '@',
                validations: '<',
            },
            templateUrl: 'app/_core/controls/form-control/form-control-validation-block/form-control-validation-block.html',
            require: '^^form',
            link: function (scope: ng.IScope, element: JQuery, attrs: ng.IAttributes, ngFormController: ng.IFormController): void {
                scope.form = ngFormController;
            },
            controller: FormControlValidationBlockDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixFormControlValidationBlock', FormControlValidationBlockDirective);
}
