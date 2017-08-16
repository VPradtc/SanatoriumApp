module pinguinPortal.app.core.validation {

    export abstract class AsyncValidator implements IValidator {

        public name: string;

        public abstract validate(modelValue: any, viewValue: any): ng.IPromise<any>;

        public attach(controller: ng.INgModelController): void {
            controller.$asyncValidators[this.name] = this.validate.bind(this);
        }
    }
}