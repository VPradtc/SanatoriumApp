module pinguinPortal.app.core.controls {

    import GridFieldConfigModel = app.core.controls.GridFieldConfigModel;

    export interface IOrderByGridRequestModel {
        orderByField: string;
        ascending?: boolean;
    }

    export interface IGetByPageGridRequestModel {
        page: number;
        pageSize: number;
    }

    interface IGridControlScope extends ng.IScope {
        fields: Array<GridFieldConfigModel>;
        rows: Array<any>;
        isItemsAllChecked: boolean;
    }

    export class GridControlDirectiveController {
        static $inject = [
            '$scope',
            '$state',
            'gridPageSize',
        ];

        private readonly classDictionary: any;

        constructor(
            private readonly vm: IGridControlScope,
            private readonly $state: ng.ui.IStateService,
            private readonly pageSize: number) {

            this.vm.defaultCellWidth = (100 / this.vm.fields.length) + '%';

            this.vm.itemClick = this.vm.itemClickHandler || (() => <void>void 0);
            this.vm.orderBy = this.vm.orderByHandler || (() => <void>void 0);
            this.vm.getFieldLabelClasses = this.getFieldLabelClasses.bind(this);
            this.vm.isItemsAllChecked = true;

            this.classDictionary = {
                'true': 'fa fa-caret-up',
                'false': 'fa fa-caret-down',
                'null': '',
            };
        }

        public getFieldLabelClasses(field: GridFieldConfigModel): string {

            let request = this.getRequestFromUri(this.$state.params.request);

            return (field.name === request.orderByField)
                ? (this.classDictionary[request.ascending + ''])
                : '';
        }

        private getRequestFromUri(query: string): any {
            let defaultRequest = {
                folderId: <number>null,
                page: 0,
                pageSize: this.pageSize,
                orderByField: <string>null,
                ascending: true,
            };

            if (query === undefined) {
                return defaultRequest;
            }

            return JSON.parse('{"' + decodeURI(query).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g, '":"') + '"}');
        }

    }

    function gridControlDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                fields: '<',
                rows: '<',
                itemClickHandler: '<?',
                orderByHandler: '<?',
            },
            controller: GridControlDirectiveController,
            templateUrl: 'app/_core/controls/grid-control/grid-control.html',
            transclude: {
                'header': '?gridHeader',
                'body': '?gridBody'
            }
        };
    }
    angular.module('pinguinPortal').directive('ixGridControl', gridControlDirective);
}