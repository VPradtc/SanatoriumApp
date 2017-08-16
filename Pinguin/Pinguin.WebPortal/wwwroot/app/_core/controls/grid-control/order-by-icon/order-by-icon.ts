module pinguinPortal.app.core.controls {
    import IOrderByGridRequestModel = app.core.controls.IOrderByGridRequestModel;

    interface IOrderByIconScope extends ng.IScope {
        orderByRequest: IOrderByGridRequestModel,
        field: string,
    }

    export class OrderByIconDirectiveController {
        static $inject = [
            '$scope',
        ];

        constructor(
            private readonly vm: IOrderByIconScope
        ) {
            vm.getIconClass = this.getIconClass.bind(this);
        }

        public getIconClass(): string {
            if (this.vm.field !== this.vm.orderByRequest.orderByField
                || this.vm.orderByRequest.ascending === undefined
                || this.vm.orderByRequest.ascending === null) {
                return undefined;
            }

            var targetClass = (this.vm.orderByRequest.ascending === true
                ? 'fa fa-caret-up'
                : 'fa fa-caret-down'
            );

            return targetClass;
        }
    }

    function OrderByIconDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                field: '@',
                orderByRequest: '<',
            },
            controller: OrderByIconDirectiveController,
            templateUrl: 'app/_core/controls/grid-control/order-by-icon/order-by-icon.html',
        };
    }
    angular.module('pinguinPortal').directive('ixOrderByIcon', OrderByIconDirective);
}
