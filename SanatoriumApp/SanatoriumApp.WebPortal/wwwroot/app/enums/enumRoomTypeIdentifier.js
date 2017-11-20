angular.module('DataAccessApp').factory('enumRoomTypeIdentifier', EnumRoomTypeIdentifier);

function EnumRoomTypeIdentifier() {

    return {
        regular: 1,
        lux: 2,
    };
}
