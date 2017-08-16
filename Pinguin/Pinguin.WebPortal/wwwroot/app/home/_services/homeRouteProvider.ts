module pinguinPortal.app.home.services {
    import CompanyTypeIdentifier = app.core.models.enums.CompanyTypeIdentifier;

    interface IRouteBinding {
        companyType: CompanyTypeIdentifier,
        route: string,
    }

    export class HomeRouteProvider {
        static $inject: string[] = [
        ];

        private readonly bindings: IRouteBinding[] = [
            {
                companyType: CompanyTypeIdentifier.brand,
                route: 'app.myCatalogs.allProducts.list',
            },
            {
                companyType: CompanyTypeIdentifier.distributor,
                route: 'app',
            },
            {
                companyType: CompanyTypeIdentifier.vendor,
                route: 'app',
            },
        ];

        public getRoute(companyType: CompanyTypeIdentifier): string {
            var targetBinding = this.bindings.filter(b => b.companyType === companyType)[0];

            if (targetBinding === undefined) {
                throw 'Unable to find home route for company type: ' + companyType;
            }

            var targetRoute = targetBinding.route;

            return targetRoute;
        }
    }

    angular.module('pinguinPortal').service('homeRouteProvider', HomeRouteProvider);
}
