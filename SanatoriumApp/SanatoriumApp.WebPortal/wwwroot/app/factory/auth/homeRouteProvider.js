'use strict'
angular.module('DataAccessApp').factory('homeRouteProvider',
    ['enumRoleIdentifier', 'authService', HomeRouteProvider]);
function HomeRouteProvider(enumRoleIdentifier, authService) {

    var _routes = {
        default: 'app.auth.login'
    };
    _routes[enumRoleIdentifier.admin] = 'app.main.user.index'

    var _getRouteFor = function (roleIdentifier) {
        return routes[roleIdentifier] || _routes.default;
    };

    var _getRoute = function() {
        var authData = authService.loadAuthenticationData();

        if (authData && authData.role === undefined) {
            return _routes.default;
        }

        return _routes[authData.role] || _routes.default;
    }

    return {
        getRouteFor: _getRouteFor,
        getRoute: _getRoute,
    }
}