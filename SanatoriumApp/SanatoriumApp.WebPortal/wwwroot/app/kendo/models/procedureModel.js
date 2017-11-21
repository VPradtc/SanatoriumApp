'use strict'
angular.module('DataAccessApp').factory('procedureModel', [ProcedureModel]);

function ProcedureModel() {
    return kendo.data.Model.define({
        id: 'id',
        fields: {
            clientName: { type: 'string' },
            procedureName: { type: 'string' },
            scheduledDate: { type: 'date' },
        },
    });
}
