module pinguinPortal.app.home {

    import CompanyInfoService = app.services.CompanyInfoService;
    import ICurrentCompanyInfo = app.models.ICurrentCompanyInfo;
    import HomeRouteProvider = app.home.services.HomeRouteProvider;

    interface IHomeViewScope extends ng.IScope {
    }

    class HomeViewDirectiveController {
        static $inject = [
            '$scope',
            '$state',
            'companyInfoService',
            'homeRouteProvider',
        ];

        constructor(
            private readonly vm: IHomeViewScope
            , private readonly $state: ng.ui.IStateService
            , private readonly companyInfoService: CompanyInfoService
            , private readonly homeRouteProvider: HomeRouteProvider
        ) {
            companyInfoService.getCurrentCompanyInfo()
                .then(companyInfo => this.goHome(companyInfo));
        }

        private goHome(companyInfo: ICurrentCompanyInfo): void {
            var currentCompanyType = companyInfo.typeId;

            var targetRoute = this.homeRouteProvider.getRoute(currentCompanyType);

            this.$state.go(targetRoute);
        }
    }

    function HomeViewDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
            },
            templateUrl: 'app/home/home-view.html',
            controller: HomeViewDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixHomeView', HomeViewDirective);
}
