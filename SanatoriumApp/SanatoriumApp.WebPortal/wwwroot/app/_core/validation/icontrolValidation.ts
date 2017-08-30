module pinguinPortal.app.core.validation {

    export interface IControlValidation {

        validator: IValidator;
        message: string;
        args?: Array<string>
    }
}