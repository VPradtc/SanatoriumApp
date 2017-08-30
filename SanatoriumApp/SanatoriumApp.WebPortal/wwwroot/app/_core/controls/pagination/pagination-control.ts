module pinguinPortal.app.core.controls.pagination {

    class PaginationControlDirectiveController {
        static $inject = [
            '$scope',
        ];

        public readonly paginationRadius: number = 3;

        constructor(
            private readonly vm: ng.IScope
        ) {
            vm.paginationRadius = this.paginationRadius;

            vm.setPage = this.setPage.bind(this);
            vm.pageRange = this.pageRange.bind(this);
            vm.isCurrentPage = this.isCurrentPage.bind(this);
            vm.isAnyData = this.isAnyData.bind(this);
        }

        public setPage(page: number): void {
            this.vm.config.currentPage = page;
            this.vm.config.submitAction(page);
        }

        public pageRange(): number[] {
            var result = [];
            let min = (this.vm.config.currentPage - this.vm.paginationRadius < 0)
                ? 0
                : this.vm.config.currentPage - this.vm.paginationRadius;
            let max = (this.vm.config.currentPage + this.vm.paginationRadius > this.vm.config.totalPages)
                ? this.vm.config.totalPages
                : this.vm.config.currentPage + this.vm.paginationRadius;

            for (var i = min; i < max; i += 1) {
                result.push(i);
            }

            return result;
        }

        public isCurrentPage(page: number): boolean {
            return this.vm.config.currentPage === page;
        }

        public isAnyData(): boolean {
            return this.vm.config.totalPages > 0;
        }
    }

    function PaginationControlDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                config: '<',
            },
            templateUrl: 'app/_core/controls/pagination/pagination-control.html',
            controller: PaginationControlDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixPaginationControl', PaginationControlDirective);
}
