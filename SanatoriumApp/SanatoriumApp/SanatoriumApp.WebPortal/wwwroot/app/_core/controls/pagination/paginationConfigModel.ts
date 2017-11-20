module pinguinPortal.app.core.controls.pagination {
    export class PaginationConfigModel {
        public totalPages: number;

        constructor(public readonly submitAction: any, public currentPage: number = 0) {

        }

    }

}
