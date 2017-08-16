module pinguinPortal.app.core.autocomplete {
    import IControlValidation = app.core.validation.IControlValidation;
    import IValidator = app.core.validation.IValidator;

    interface IAutocompleteControlDirectiveScope extends ng.IScope {
        getDatasetFunc: (term: string) => ng.IPromise<any[]>;
        validations: IControlValidation[];
    }

    class AutocompleteDirectiveController {
        static $inject = [
            '$scope'
        ];

        constructor(
            private readonly vm: IAutocompleteControlDirectiveScope
        ) {
            vm.search = this.search.bind(this);
        }

        public search(term: string): ng.IPromise<any[]> {
            return this.vm.getDatasetFunc(term);
        }
    }

    function AutocompleteDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            templateUrl: 'app/_core/controls/autocomplete-control/autocomplete-control.html',
            scope: {
                label: '<',
                field: '@',
                entity: '<',
                getDatasetFunc: '<',
                validations: '<',
                keyField: '@',
                valueField: '@',
                showLabel: '<'
            },
            require: '^^form',
            link: function (scope: ng.IScope, element: JQuery, attrs: ng.IAttributes, ngFormController: ng.IFormController): void {
                scope.form = ngFormController;
            },
            controller: AutocompleteDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixAutocompleteControl', AutocompleteDirective);
}