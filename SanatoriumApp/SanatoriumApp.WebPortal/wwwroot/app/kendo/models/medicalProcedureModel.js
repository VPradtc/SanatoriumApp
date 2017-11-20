'use strict'
angular.module('DataAccessApp').factory('medicalProcedureModel', [MedicalProcedureModel]);

function MedicalProcedureModel() {
    return kendo.data.Model.define({
        id: 'id',
        fields: {
            name: { type: 'string' },
            baseCost: { type: 'number' },
        },
    });
}
