'use strict';
angular.module('DataAccessApp').controller('roomController',
['$scope', 'roomService', 'roomModel', RoomController]);

function RoomController($scope, roomService, roomModel) {
    $scope.gridConfig = {
        grid: {
            getDataUrl: roomService.getByPageUrl,
            model: roomModel,
            columns: [
                {
                    field: 'name',
                    title: 'room.name'
                },
                {
                    field: 'roomType()',
                    title: 'room.roomType',
                    sortable: {
                        compare: 'roomTypeId'
                    },
                    template: '<span i18n="#: roomType() #"></span>'
                },
                {
                    type: 'action',
                    value: ['edit', 'delete'],
                },
            ]
        },
        delete: {
            text: 'room.deleteThisRoom',
            confirmButtonText: 'common.delete',
            serviceMethod: roomService.delete
        },

        createState: 'app.main.room.create',
        editState: 'app.main.room.edit',

        view: {
            title: 'room.rooms',
            breadcrumb: [
                {
                    title: 'common.home',
                    sref: 'app.main.home'
                },
                {
                    title: 'room.rooms',
                },
            ],
            buttons: [
                {
                    text: 'common.create',
                    state: 'app.main.room.create'
                },
            ],
        }
    };
}

