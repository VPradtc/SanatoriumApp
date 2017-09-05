module pinguinPortal.app.config {
    export class StateModes {
        public static localizationEdit: string = 'localizationEdit';
        public static generalEdit: string = 'generalEdit';
    }

    angular.module('pinguinPortal').constant('stateModes', StateModes);
}