module pinguinPortal.app.core.http {

    export class BaseHttpService {
        static $inject = [
            '$http',
            '$rootScope',
            '$httpParamSerializerJQLike',
            'urlBuilder',
        ];

        private readonly path: string;

        constructor(
            private readonly $http: ng.IHttpService
            , private readonly $rootScope: ng.IRootScopeService
            , private readonly $httpParamSerializerJQLike: ng.IHttpParamSerializer
            , private readonly urlBuilder: app.core.http.UrlBuilder
        ) {
        }

        public get<TResponse>(
            url: string
            , params: {} = undefined
            , triggerLoader: boolean = true): ng.IPromise<TResponse> {

            var queryString = this.urlBuilder.build(url, params);

            if (triggerLoader === true) {
                this.$rootScope.$broadcast('startLoading');
            }

            var resultPromise = this.$http
                .get(queryString)
                .then(response => {
                    if (triggerLoader === true) {
                        this.$rootScope.$broadcast('stopLoading');
                    }

                    return <TResponse>response.data;
                },
                error => {
                    if (triggerLoader === true) {
                        this.$rootScope.$broadcast('stopLoading');
                    }

                    throw error;
                });

            return resultPromise;
        }

        public post<TResponse>(
            url: string
            , data: any = undefined
            , triggerLoader: boolean = true): ng.IPromise<TResponse> {

            var queryString = url;

            if (triggerLoader === true) {
                this.$rootScope.$broadcast('startLoading');
            }

            var resultPromise = this.$http
                .post(queryString, data)
                .then(response => {
                    if (triggerLoader === true) {
                        this.$rootScope.$broadcast('stopLoading');
                    }

                    return <TResponse>response.data;
                },
                error => {
                    if (triggerLoader === true) {
                        this.$rootScope.$broadcast('stopLoading');
                    }

                    throw error;
                });

            return resultPromise;
        }
    }

    angular.module('pinguinPortal').service('baseHttpService', BaseHttpService);
}
