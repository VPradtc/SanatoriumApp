'use strict'
angular.module('DataAccessApp').factory('roomModel', ['roomTypeDefinitionProvider', RoomModel]);

function RoomModel(roomTypeDefinitionProvider) {
    return kendo.data.Model.define({
        id: 'id',
        fields: {
            name: { type: 'string' },
            capacity: { type: 'number' },
            roomTypeId: { type: 'number' },
        },
        roomType: function () {
            return roomTypeDefinitionProvider.getByIdentifier(this.roomTypeId).name;
        },
    });
}
