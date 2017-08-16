module pinguinPortal.app.dialog {
    function dialogViewDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                title: '<?',
                text: '<?',
            },
            transclude: {
                dialogHeader: '?dialogHeader',
                dialogBody: '?dialogBody',
                dialogButtons: '?dialogButtons',
            },
            templateUrl: 'app/dialog/_elements/dialog-view.html',
        };
    }

    angular.module('pinguinPortal').directive('ixDialogView', dialogViewDirective);
}