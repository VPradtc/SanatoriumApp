module pinguinPortal.app.core.models.enums {
    interface IFieldValues {
        name: string;
        value: FieldTypesIdentifier
    }
    export class FieldTypesIdentifierExtension {
        public integer: IFieldValues;
        public decimal: IFieldValues;
        public string: IFieldValues;
        public date: IFieldValues;
        public text: IFieldValues;

        constructor() {
            this.integer = {
                name: 'integer',
                value: FieldTypesIdentifier.integer
            };
            this.decimal = {
                name: 'decimal',
                value: FieldTypesIdentifier.decimal
            };
            this.string = {
                name: 'string',
                value: FieldTypesIdentifier.string
            };
            this.date = {
                name: 'date',
                value: FieldTypesIdentifier.date
            };
            this.text = {
                name: 'text',
                value: FieldTypesIdentifier.text
            };
        }
    }
}