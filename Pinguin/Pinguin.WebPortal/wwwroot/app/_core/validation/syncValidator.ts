module pinguinPortal.app.core.validation {

    export abstract class SyncValidator implements IValidator {

        public name: string;

        public abstract validate(modelValue: any, viewValue: any): boolean;

        public attach(controller: ng.INgModelController): void {
            controller.$validators[this.name] = this.validate.bind(this);
        }
    }
}