module pinguinPortal.app.core.validation {

    export class EqualsValidator extends SyncValidator {

        constructor(private readonly value: any) {
            super();
            this.name = 'equals';
        }

        public validate(modelValue: any, viewValue: any): boolean {
            return (viewValue === this.value)
                && (viewValue !== null)
                && (viewValue !== '');
        }
    }
}