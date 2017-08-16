module pinguinPortal.app.footer {
    class AppFooterDirectiveController {
        static $inject = [
            '$scope',
        ];

        constructor(
            private readonly vm: ng.IScope
        ) {
        }
    }

    function AppFooterDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
            },
            templateUrl: 'app/_elements/footer/app-footer.html',
            controller: AppFooterDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixAppFooter', AppFooterDirective);
}