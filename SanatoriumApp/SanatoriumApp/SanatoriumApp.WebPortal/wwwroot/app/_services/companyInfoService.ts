module pinguinPortal.app.services {

    import CompanyTypeIdentifier = app.core.models.enums.CompanyTypeIdentifier;
    import UrlSettings = app.config.UrlSettings;
    import BaseHttpService = app.core.http.BaseHttpService;
    import ICurrentCompanyInfo = app.models.ICurrentCompanyInfo;

    export class CompanyInfoService {
        static $inject = [
            'baseHttpService',
            '$q'
        ];

        private currentCompanyInfo: ICurrentCompanyInfo;

        constructor(
            private readonly baseHttpService: BaseHttpService
            , private readonly $q: ng.IQService
        ) {
            this.loadCompanyInfo().then((response) => {
                this.currentCompanyInfo = response;
            });
        }

        private loadCompanyInfo(): ng.IPromise<ICurrentCompanyInfo> {
            return this.baseHttpService.get<ICurrentCompanyInfo>(UrlSettings.serverApiUri + '/api/catalog/' + 'GetCurrentCompanyInfo');
        }

        public getCurrentCompanyInfo(): ng.IPromise<ICurrentCompanyInfo> {
            return (this.currentCompanyInfo !== null
                && this.currentCompanyInfo !== undefined)
                ? this.$q.when(this.currentCompanyInfo)
                : this.loadCompanyInfo();
        }

        public checkRole(roleId: CompanyTypeIdentifier): boolean {
            if (this.currentCompanyInfo === undefined
                || this.currentCompanyInfo === null
            ) {
                return false;
            }

            var isTargetRole = this.currentCompanyInfo.typeId === roleId;

            return isTargetRole;
        }
    }

    angular.module('pinguinPortal').service('companyInfoService', CompanyInfoService);
}