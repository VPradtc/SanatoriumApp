angular.module('DataAccessApp').factory('enumRoleIdentifier', EnumRoleIdentifier);

function EnumRoleIdentifier() {

    return {
        admin: 1,
        user: 2,
    };
}
