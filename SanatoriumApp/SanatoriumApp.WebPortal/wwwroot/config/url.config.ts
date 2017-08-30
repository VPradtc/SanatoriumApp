module pinguinPortal.app.config {

    export class UrlSettings {
        public static readonly serverApiUri: string = 'http://localhost/Pinguin.WebPortal';
        public static readonly tokenUrl: string = 'http://localhost/Pinguin.WebPortal/token';
        public static readonly clientId: string = 'pinguinWebPortal';
    }
    angular.module('pinguinPortal').constant('urlSettings', UrlSettings);
}
