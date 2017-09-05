module pinguinPortal.app.config {
    export class CustomEvents {

        public static readonly headerLanguageSelected: string = 'ixHeaderLanguageSelected';
    }

    angular.module('pinguinPortal').constant('customEvents', CustomEvents);
}