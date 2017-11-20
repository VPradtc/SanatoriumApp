'use strict';
angular.module('DataAccessApp').controller('roomEditController',
['$scope', 'roomService', '$state', 'roomFormFactory', '$q', RoomEditController]);
function RoomEditController($scope, roomService, $state, formFactory, $q) {

    var vm = $scope;

    var _labelMap = {
        'edit': {
            title: 'room.editRoom',
        },
        'create': {
            title: 'room.createRoom',
        }
    };

    var _getLabels = function () {
        return _labelMap[$state.current.mode];
    };

    var _init = function () {

        vm.options = {
            backState: 'app.main.room.index',
            fields: formFactory.create(),
            serviceMethods: {
                getById: roomService.getById,
                edit: roomService.update,
                create: roomService.create,
            },
            view: {
                breadcrumb: [
                        {
                            title: 'common.home',
                            sref: 'app.main.home'
                        },
                        {
                            title: 'room.room',
                            sref: 'app.main.room.index'
                        },
                ],
                labels: _getLabels(),
            },
        };
    }

    var preInitPromise = $state.current.mode === 'create'
        ? $q.when({})
        : roomService.getById($state.params.id)

    preInitPromise.then(_init);
}

