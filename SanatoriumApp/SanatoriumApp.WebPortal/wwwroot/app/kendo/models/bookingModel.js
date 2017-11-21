'use strict'
angular.module('DataAccessApp').factory('bookingModel', [BookingModel]);

function BookingModel() {
    return kendo.data.Model.define({
        id: 'id',
        fields: {
            clientId: { type: 'number' },
            clientName: { type: 'string' },
            roomId: { type: 'number' },
            roomName: { type: 'string' },
            startDate: { type: 'date' },
            endDate: { type: 'date' },
        },
    });
}
