module pinguinPortal.app.header {
    import AuthService = app.auth.services.AuthService;
    import BaseHttpService = app.core.http.BaseHttpService;
    import UrlSettings = app.config.UrlSettings;
    import CompanyTypeIdentifier = app.core.models.enums.CompanyTypeIdentifier;
    import AccountService = app.services.AccountService;

    class CompanyInfo {
        public id: number;
        public name: string;
        public companyTypeId: CompanyTypeIdentifier;
        public companyLogo: ByteString;
    }

    class AppHeaderDirectiveController {
        static $inject = [
            '$scope',
            '$state',
            'authService',
            'baseHttpService',
            'accountService',
        ];

        constructor(
            private readonly vm: ng.IScope
            , private readonly $state: ng.ui.IStateService
            , private readonly authService: AuthService
            , private readonly baseHttpService: BaseHttpService
            , private readonly accountService: AccountService
        ) {
            this.vm.toggleSidebar = this.toggleSidebar.bind(this);
            this.vm.logout = this.logout.bind(this);
            this.vm.getFirstName = this.getFirstName.bind(this);
        }

        public toggleSidebar(): void {
            angular.element('body').toggleClass(`ix-css-page-sidebar-closed
                                                     ix-css-page-sidebar-closed-hide-logo`);
        }

        public logout(): void {
            this.accountService.logout()
                .then(() => this.authService.logout());
        }

        public getFirstName(): string {
            return this.authService.authData.firstName;
        }
    }

    function AppHeaderDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
            },
            templateUrl: 'app/_elements/header/app-header.html',
            controller: AppHeaderDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixAppHeader', AppHeaderDirective);
}