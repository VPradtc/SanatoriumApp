'use strict';
angular.module('DataAccessApp').controller('clientController',
['$scope', 'clientService', 'clientModel', ClientController]);

function ClientController($scope, clientService, clientModel) {
    $scope.gridConfig = {
        grid: {
            getDataUrl: clientService.getByPageUrl,
            model: clientModel,
            columns: [
                {
                    field: 'firstName',
                    title: 'client.firstName'
                },
                {
                    field: 'lastName',
                    title: 'client.lastName'
                },
                {
                    field: 'passport',
                    title: 'client.passport'
                },
                {
                    type: 'action',
                    value: ['edit', 'delete'],
                },
            ]
        },
        delete: {
            text: 'client.deleteThisClient',
            confirmButtonText: 'common.delete',
            serviceMethod: clientService.delete
        },

        createState: 'app.main.client.create',
        editState: 'app.main.client.edit',

        view: {
            title: 'client.clients',
            breadcrumb: [
                {
                    title: 'common.home',
                    sref: 'app.main.home'
                },
                {
                    title: 'client.clients',
                },
            ],
            buttons: [
                {
                    text: 'common.create',
                    state: 'app.main.client.create'
                },
            ],
        }
    };
}

