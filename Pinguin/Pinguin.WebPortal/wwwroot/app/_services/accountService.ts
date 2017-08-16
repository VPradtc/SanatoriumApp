module pinguinPortal.app.services {
    import UrlSettings = app.config.UrlSettings;

    export class AccountService {
        static $inject = [
            'baseHttpService',
        ];

        private readonly path: string;

        constructor(
            private readonly baseHttpService: app.core.http.BaseHttpService
        ) {
            this.path = UrlSettings.serverApiUri;
        }

        public logout(): ng.IPromise<any> {
            var url = this.path + '/logout';

            return this.baseHttpService.post<any>(url);
        }
    }

    angular.module('pinguinPortal').service('accountService', AccountService);
}
