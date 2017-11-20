module pinguinPortal.app.core.http {

    export class UrlBuilder {
        static $inject = [
            '$httpParamSerializerJQLike',
        ];

        private readonly path: string;

        constructor(
            private readonly $httpParamSerializerJQLike: ng.IHttpParamSerializer
        ) {
        }

        public build(url: string, params: Object): string {

            if (params === undefined) {
                return url;
            }

            var parts = this.$httpParamSerializerJQLike(params);
            var paramsDelimeter = url.indexOf('?') === -1 ? '?' : '&';

            return url + paramsDelimeter + parts;
        }
    }

    angular.module('pinguinPortal').service('urlBuilder', UrlBuilder);
}