angular.module('DataAccessApp').factory('clientFormFactory',
[ClientFormFactory]);

function ClientFormFactory() {

    var _create = function (passportValidator) {

        var _fields = [
            {
                field: 'firstName',
                label: 'client.firstName',
                attrs: {
                    type: 'text',
                    name: 'firstName',
                    required: '',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'client.firstNameIsRequired',
                    },
                ],
            },
            {
                field: 'lastName',
                label: 'client.lastName',
                attrs: {
                    type: 'text',
                    name: 'lastName',
                    required: '',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'client.lastNameIsRequired',
                    },
                ],
            },
            {
                field: 'passport',
                label: 'client.passport',
                attrs: {
                    type: 'text',
                    name: 'passport',
                    required: '',
                    ngModelOptions: '{ debounce: 1000 }',
                },
                validators: [
                    {
                        async: true,
                        validation: 'unique',
                        validator: passportValidator,
                    }
                ],
                messages: [
                    {
                        validation: 'required',
                        text: 'client.passportIsRequired',
                    },
                    {
                        validation: 'unique',
                        text: 'client.clientWithSuchPassportAlreadyExists',
                    },
                ],
            },
        ];

        return _fields;
    }

    return {
        create: _create,
    }
}
