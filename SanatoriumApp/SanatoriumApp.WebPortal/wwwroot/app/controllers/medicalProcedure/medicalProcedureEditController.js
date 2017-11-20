'use strict';
angular.module('DataAccessApp').controller('medicalProcedureEditController',
['$scope', 'medicalProcedureService', '$state', 'medicalProcedureFormFactory', '$q', MedicalProcedureEditController]);
function MedicalProcedureEditController($scope, medicalProcedureService, $state, formFactory, $q) {

    var vm = $scope;

    var _labelMap = {
        'edit': {
            title: 'medicalProcedure.editMedicalProcedure',
        },
        'create': {
            title: 'medicalProcedure.createMedicalProcedure',
        }
    };

    var _getLabels = function () {
        return _labelMap[$state.current.mode];
    };

    var _init = function () {

        vm.options = {
            backState: 'app.main.medicalProcedure.index',
            fields: formFactory.create(),
            serviceMethods: {
                getById: medicalProcedureService.getById,
                edit: medicalProcedureService.update,
                create: medicalProcedureService.create,
            },
            view: {
                breadcrumb: [
                        {
                            title: 'common.home',
                            sref: 'app.main.home'
                        },
                        {
                            title: 'medicalProcedure.medicalProcedure',
                            sref: 'app.main.medicalProcedure.index'
                        },
                ],
                labels: _getLabels(),
            },
        };
    }

    var preInitPromise = $state.current.mode === 'create'
        ? $q.when({})
        : medicalProcedureService.getById($state.params.id)

    preInitPromise.then(_init);
}

