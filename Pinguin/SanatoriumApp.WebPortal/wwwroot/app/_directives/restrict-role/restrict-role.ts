module pinguinPortal.app.directives {
    import CompanyInfoService = app.services.CompanyInfoService;
    import CompanyTypeIdentifier = app.core.models.enums.CompanyTypeIdentifier;

    interface IRestrictRoleDirectiveScope extends ng.IScope {
        roles: CompanyTypeIdentifier[],
    }

    class RestrictRoleDirectiveController {
        static $inject = [
            '$scope',
            'companyInfoService',
        ];

        constructor(
            private readonly vm: IRestrictRoleDirectiveScope
            , private readonly companyInfoService: CompanyInfoService
        ) {
            vm.isAllowed = this.isAllowed.bind(this);
        }

        public isAllowed(): boolean {
            var isAllowed = this.vm.roles.some(roleId => this.companyInfoService.checkRole(roleId));

            return isAllowed;
        }
    }

    function RestrictRoleDirective(): ng.IDirective {
        return {
            restrict: 'EA',
            scope: {
                roles: '<',
            },
            transclude: true,
            templateUrl: 'app/_directives/restrict-role/restrict-role.html',
            controller: RestrictRoleDirectiveController,
        };
    }

    angular.module('pinguinPortal').directive('ixRestrictRole', RestrictRoleDirective);
}
