module pinguinPortal.app.sidebar {
    import AppSidebarItem = app.sidebar.items.AppSidebarItem;
    import UrlSettings = app.config.UrlSettings;

    import CompanyInfoService = app.services.CompanyInfoService;
    import ICurrentCompanyInfo = app.models.ICurrentCompanyInfo;
    import CompanyTypeIdentifier = app.core.models.enums.CompanyTypeIdentifier;

    interface IAppSidebarDirectiveScope extends ng.IScope {
        topItems: AppSidebarItem[],
        bottomItems: AppSidebarItem[],
    }

    class AppSidebarDirectiveController {
        static $inject = [
            '$scope',
            'companyInfoService'
        ];

        private currentCompanyInfo: ICurrentCompanyInfo;

        constructor(
            private readonly vm: IAppSidebarDirectiveScope
            , private readonly companyInfoService: CompanyInfoService
        ) {
            this.createItems();
            this.vm.isVisible = this.isVisible.bind(this);
        }

        private createItems(): void {
            this.vm.topItems = [
                new AppSidebarItem(
                    'app.myCatalogs.allProducts.list'
                    , 'icon-grid'
                    , 'app.myCatalogs'
                    , null
                    , true
                    , null
                    , [CompanyTypeIdentifier.brand]
                ),
                new AppSidebarItem(
                    'app.myCatalogs'
                    , 'icon-grid'
                    , 'app.myCatalogs'
                    , null
                    , true
                    , null
                    , [CompanyTypeIdentifier.vendor, CompanyTypeIdentifier.distributor]
                ),
                new AppSidebarItem(
                    'app.productTypes'
                    , 'icon-layers'
                    , 'app.productTypes'
                    , null
                    , false
                    , null
                    , [CompanyTypeIdentifier.brand]
                ),
                new AppSidebarItem(
                    'app.subscriptions'
                    , 'icon-star'
                    , 'app.subscriptions'
                    , null
                    , false
                    , null
                    , [CompanyTypeIdentifier.vendor]
                ),
            ];

            this.vm.bottomItems = [
            ];
        }

        public isVisible(model: AppSidebarItem): boolean {
            var isVisible = model.roleAccess.some(roleId => this.companyInfoService.checkRole(roleId));

            return isVisible;
        }
    }

    function AppSidebarDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
            },
            templateUrl: 'app/_elements/sidebar/app-sidebar.html',
            controller: AppSidebarDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixAppSidebar', AppSidebarDirective);
}
