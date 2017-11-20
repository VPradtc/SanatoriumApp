angular.module('DataAccessApp').factory('medicalProcedureFormFactory',
[MedicalProcedureFormFactory]);

function MedicalProcedureFormFactory() {

    var _create = function () {

        var _fields = [
            {
                field: 'name',
                label: 'medicalProcedure.name',
                attrs: {
                    type: 'text',
                    name: 'name',
                    required: '',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'medicalProcedure.nameIsRequired',
                    },
                ],
            },
            {
                field: 'baseCost',
                label: 'medicalProcedure.baseCost',
                attrs: {
                    type: 'number',
                    name: 'baseCost',
                    required: '',
                    min: '0',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'medicalProcedure.baseCostIsRequired',
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
