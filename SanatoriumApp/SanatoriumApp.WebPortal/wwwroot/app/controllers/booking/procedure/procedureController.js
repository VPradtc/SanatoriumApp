'use strict';
angular.module('DataAccessApp').controller('procedureController',
    ['$scope', '$state', 'procedureService', 'procedureModel', 'shortDateColumnTemplateFactory', ProcedureController]);

function ProcedureController($scope, $state, procedureService, procedureModel, shortDateColumnTemplateFactory) {

    $scope.bookingId = $state.params.bookingId;

    $scope.gridConfig = {
        grid: {
            getDataUrl: procedureService.getByPageUrl,
            params: [
                {
                    name: 'bookingId',
                    selector: () => $scope.bookingId
                },
            ],
            model: procedureModel,
            columns: [
                {
                    field: 'scheduledDate',
                    title: 'procedure.scheduledDate',
                    template: shortDateColumnTemplateFactory.create('scheduledDate'),
                },
                {
                    field: 'medicalProcedureName',
                    title: 'procedure.medicalProcedure'
                },
                {
                    field: 'userName',
                    title: 'procedure.employee'
                },
                {
                    type: 'action',
                    value: ['edit', 'delete'],
                },
            ]
        },
        delete: {
            text: 'procedure.deleteThisProcedure',
            confirmButtonText: 'common.delete',
            serviceMethod: procedureService.delete
        },

        createState: 'app.main.booking.procedure.create',
        editState: 'app.main.booking.procedure.edit',

        backState: 'app.main.booking.index',

        view: {
            title: 'procedure.procedures',
            breadcrumb: [
                {
                    title: 'common.home',
                    sref: 'app.main.home'
                },
                {
                    title: 'common.bookings',
                    sref: 'app.main.booking.index'
                },
                {
                    title: 'procedure.procedures',
                },
            ],
            buttons: [
                {
                    text: 'common.create',
                    state: 'app.main.booking.procedure.create'
                },
            ],
        }
    };
}

