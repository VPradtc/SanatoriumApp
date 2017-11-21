angular.module('DataAccessApp').factory('procedureFormFactory',
    ['procedureService', ProcedureFormFactory]);

function ProcedureFormFactory(procedureService) {

    var _create = function () {

        var _fields = [
            {
                field: 'scheduledDate',
                label: 'procedure.scheduledDate',
                attrs: {
                    type: 'date',
                    name: 'scheduledDate',
                    required: '',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'procedure.scheduledDateIsRequired',
                    },
                ],
            },
            {
                field: 'medicalProcedureId',
                label: 'procedure.medicalProcedure',
                optionLabel: 'procedure.selectMedicalProcedure',
                attrs: {
                    type: 'select',
                    name: 'medicalProcedureId',
                    required: '',
                },
                dataSource: {
                    static: false,
                    data: procedureService.getMedicalProceduresUrl,
                },
                options: {
                    dataTextField: 'name',
                    dataValueField: 'identifier',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'procedure.medicalProcedureIsRequired'
                    },
                ],
            },
            {
                field: 'userId',
                label: 'procedure.employee',
                optionLabel: 'procedure.selectClient',
                attrs: {
                    type: 'select',
                    name: 'userId',
                    required: '',
                },
                dataSource: {
                    static: false,
                    data: procedureService.getUsersUrl,
                },
                options: {
                    dataTextField: 'name',
                    dataValueField: 'identifier',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'procedure.employeeIsRequired'
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
