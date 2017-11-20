angular.module('DataAccessApp').factory('navbarFactory',
['enumRoleIdentifier', NavbarFactory]);
function NavbarFactory(enumRoleIdentifier) {

    var _createNavbar = function () {

        var navbar = {
            title: "",
            items: [
                {
                    title: 'common.users',
                    state: 'app.main.user.index',
                    icon: 'fa fa-user',
                    restrict: {
                        roles: [enumRoleIdentifier.admin],
                    },
                },
                {
                    title: 'common.medicalProcedures',
                    state: 'app.main.medicalProcedure.index',
                    icon: 'fa fa-user',
                },
                {
                    title: 'common.rooms',
                    state: 'app.main.room.index',
                    icon: 'fa fa-user',
                },
            ]
        };

        return navbar;
    };

    return {
        createNavbar: _createNavbar
    };
}
