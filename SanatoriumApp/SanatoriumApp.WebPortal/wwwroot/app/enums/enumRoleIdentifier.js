angular.module('DataAccessApp').factory('enumRoleIdentifier', EnumRoleIdentifier);

function EnumRoleIdentifier() {

    return {
        admin: 1,
        medicalStaff: 2,
        utilityStaff: 3,
    };
}
