module pinguinPortal.app.core.validation {

    export interface IValidator {
        name: string;
        attach(controller: ng.INgModelController): void;
    }
}