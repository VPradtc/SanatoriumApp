'use strict'
angular.module('DataAccessApp').factory('roomTypeDefinitionProvider', ['enumRoomTypeIdentifier', '$filter', RoomTypeDefinitionProvider]);

function RoomTypeDefinitionProvider(enumRoomTypeIdentifier, $filter) {

    var _definitions = [
        {
            identifier: enumRoomTypeIdentifier.regular,
            name: 'room.type_regular',
        },
        {
            identifier: enumRoomTypeIdentifier.lux,
            name: 'room.type_lux',
        },
    ];

    return {
        getAll: function () {
            return _definitions;
        },
        getByIdentifier: function (identifier) {
            return $filter('filter')(_definitions, { identifier: identifier })[0];
        }
    };
}
