module pinguinPortal.app.sidebar.items {
    import CompanyTypeIdentifier = app.core.models.enums.CompanyTypeIdentifier;

    export class AppSidebarItem {

        constructor(
            public readonly sref: string
            , public readonly icon: string
            , public readonly text: string
            , public readonly subItems: AppSidebarSubItem[]
            , public readonly isFirst: boolean = false
            , public readonly href: string = null
            , public readonly roleAccess: Array<CompanyTypeIdentifier> = [CompanyTypeIdentifier.brand,
            CompanyTypeIdentifier.distributor,
            CompanyTypeIdentifier.vendor]
        ) {
        }
    }

    export class AppSidebarSubItem {
        constructor(
            public readonly sref: string
            , public readonly icon: string
            , public readonly text: string
        ) {
        }
    }

    interface IAppSidebarItemDirectiveScope extends ng.IScope {
        item: AppSidebarItem
    }

    class AppSidebarItemDirectiveController {
        static $inject = [
            '$scope',
            '$state',
        ];

        constructor(
            private readonly vm: IAppSidebarItemDirectiveScope
            , private readonly $state: ng.ui.IStateService
        ) {
            vm.getClass = this.getClass.bind(this);
            vm.isSelected = this.isSelected.bind(this);
        }

        public getClass(): object {
            var classMap = {
                'start': this.vm.item.isFirst === true,
                'nav-item': this.vm.item.isFirst === false,
                'active': this.isSelected()
            };

            return classMap;
        }

        public isSelected(): boolean {
            var isOwnStateSelected = this.$state.is(this.vm.item.sref);
            var isChildStateSelected = this.vm.item.subItems
                && this.vm.item.subItems.some(
                    subItem => this.$state.is(subItem.sref)
                );

            return isOwnStateSelected || isChildStateSelected;
        }

    }
    function AppSidebarItemDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            replace: true,
            scope: {
                item: '<',
            },
            templateUrl: 'app/_elements/sidebar/items/app-sidebar-item.html',
            controller: AppSidebarItemDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixAppSidebarItem', AppSidebarItemDirective);
}
