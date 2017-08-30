module pinguinPortal.app.core.validation {

    export class RequiredValidator extends SyncValidator {

        constructor() {
            super();
            this.name = 'required';
        }

        public validate(modelValue: any, viewValue: any): boolean {
            return (viewValue !== undefined)
                && (viewValue !== null)
                && (viewValue !== '');
        }
    }
}