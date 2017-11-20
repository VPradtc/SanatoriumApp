module pinguinPortal.app.config {

    export class AppConstants {
        public readonly homeRoute: string = 'app.myCatalogs.allProducts.list';
    }
    angular.module('pinguinPortal').constant('appConstants', new AppConstants());
}
