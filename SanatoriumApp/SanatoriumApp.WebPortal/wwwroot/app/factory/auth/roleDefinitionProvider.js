'use strict'
angular.module('DataAccessApp').factory('roleDefinitionProvider', ['enumRoleIdentifier', '$filter', RoleDefinitionProvider]);

function RoleDefinitionProvider(enumRoleIdentifier, $filter) {

    var _roles = [
        {
            identifier: enumRoleIdentifier.admin,
            name: 'auth.role_admin',
        },
        {
            identifier: enumRoleIdentifier.medicalStaff,
            name: 'auth.role_medicalStaff',
        },
        {
            identifier: enumRoleIdentifier.utilityStaff,
            name: 'auth.role_utilityStaff',
        },
    ];

    return {
        getAll: function () {
            return _roles;
        },
        getByIdentifier: function (identifier) {
            return $filter('filter')(_roles, { identifier: identifier })[0];
        }
    };
}
