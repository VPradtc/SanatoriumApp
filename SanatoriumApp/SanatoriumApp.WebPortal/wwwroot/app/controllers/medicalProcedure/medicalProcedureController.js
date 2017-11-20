'use strict';
angular.module('DataAccessApp').controller('medicalProcedureController',
['$scope', 'medicalProcedureService', 'medicalProcedureModel', MedicalProcedureController]);

function MedicalProcedureController($scope, medicalProcedureService, medicalProcedureModel) {
    $scope.gridConfig = {
        grid: {
            getDataUrl: medicalProcedureService.getByPageUrl,
            model: medicalProcedureModel,
            columns: [
                {
                    field: 'name',
                    title: 'medicalProcedure.name'
                },
                {
                    field: 'baseCost',
                    title: 'medicalProcedure.baseCost'
                },
                {
                    type: 'action',
                    value: ['edit', 'delete'],
                },
            ]
        },
        delete: {
            text: 'medicalProcedure.deleteThisMedicalProcedure',
            confirmButtonText: 'common.delete',
            serviceMethod: medicalProcedureService.delete
        },

        createState: 'app.main.medicalProcedure.create',
        editState: 'app.main.medicalProcedure.edit',

        view: {
            title: 'medicalProcedure.medicalProcedures',
            breadcrumb: [
                {
                    title: 'common.home',
                    sref: 'app.main.home'
                },
                {
                    title: 'medicalProcedure.medicalProcedures',
                },
            ],
            buttons: [
                {
                    text: 'common.create',
                    state: 'app.main.medicalProcedure.create'
                },
            ],
        }
    };
}

