module pinguinPortal.app.services {

    interface IPreviousState {
        state: ng.ui.IState,
        stateParams: any,
    }

    export class RouteHistoryService {
        static $inject = [
            '$state',
        ];

        private previousState: IPreviousState;

        constructor(
            private readonly $state: ng.ui.IStateService
            , private readonly asd: ng.ui.IStateParamsService
        ) {
            this.previousState = {
                state: {},
                stateParams: {}
            };
        }

        public getPreviousState(fallBackState?: string): string {
            return this.previousState !== undefined && !this.previousState.state.abstract ? this.previousState.state.name : fallBackState;
        }

        public getPreviousStateParams(): any {
            return this.previousState !== undefined ? this.previousState.stateParams : {};
        }

        public setPreviousState(state: ng.ui.IState, params: any): void {
            this.previousState.state = state;
            this.previousState.stateParams = params;
        }
    }

    angular.module('pinguinPortal').service('routeHistoryService', RouteHistoryService);
}
