module pinguinPortal.app.core.validation {

    import SyncValidator = app.core.validation.SyncValidator;

    export class FieldLengthValidator extends SyncValidator {

        private readonly fieldLength: number;

        constructor(fieldLength: number) {
            super();
            this.name = 'fieldLength';
            this.fieldLength = fieldLength;
        }

        public validate(modelValue: any, viewValue: string): boolean {
            return (viewValue === undefined ? true : viewValue.length <= this.fieldLength);
        }
    }
}