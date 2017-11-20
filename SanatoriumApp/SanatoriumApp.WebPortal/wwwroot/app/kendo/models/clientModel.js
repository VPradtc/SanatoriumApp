'use strict'
angular.module('DataAccessApp').factory('clientModel', [ClientModel]);

function ClientModel() {
    return kendo.data.Model.define({
        id: 'id',
        fields: {
            firstName: { type: 'string' },
            lastName: { type: 'string' },
            passport: { type: 'string' },
        },
    });
}
