module pinguinPortal.app.core.controls.file_form_control.directives {

    function FileModelDirective(): ng.IDirective {
        return {
            require: 'ngModel',
            restrict: 'A',
            link: function ($scope: ng.IScope
                , element: JQuery
                , attrs: ng.IAttributes
                , ngModelController: ng.INgModelController): void {

                element.bind('change', (event: any) => {
                    ngModelController.$setViewValue(event.target.files[0]);
                    $scope.$apply();
                });

                $scope.$watch(
                    () => {
                        return ngModelController.$viewValue;
                    }
                    , (value: string) => {
                        if (!value) {
                            element.val('');
                        }
                    }
                );
            }
        };
    }

    angular.module('pinguinPortal').directive('ixFileModel', FileModelDirective);
}
