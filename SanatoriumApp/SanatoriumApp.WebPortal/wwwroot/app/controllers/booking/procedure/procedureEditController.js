'use strict';
angular.module('DataAccessApp').controller('procedureEditController',
['$scope', 'procedureService', '$state', 'procedureFormFactory', '$q', ProcedureEditController]);
function ProcedureEditController($scope, procedureService, $state, formFactory, $q) {

    var vm = $scope;

    vm.bookingId = $state.params.bookingId;

    var _labelMap = {
        'edit': {
            title: 'procedure.editProcedure',
        },
        'create': {
            title: 'procedure.createProcedure',
        }
    };

    var _getLabels = function () {
        return _labelMap[$state.current.mode];
    };

    var _init = function (entity) {

        vm.options = {
            backState: 'app.main.booking.procedure.index',
            fields: formFactory.create(),
            serviceMethods: {
                getById: procedureService.getById,
                edit: procedureService.update,
                create: procedureService.create,
            },
            onCreate: function (entity) {
                entity.bookingId = vm.bookingId;
            },
            view: {
                breadcrumb: [
                        {
                            title: 'common.home',
                            sref: 'app.main.home'
                        },
                        {
                            title: 'procedure.procedure',
                            sref: 'app.main.procedure.index'
                        },
                ],
                labels: _getLabels(),
            },
        };
    }

    var preInitPromise = $state.current.mode === 'create'
        ? $q.when({})
        : procedureService.getById($state.params.id)

    preInitPromise.then(_init);
}
