'use strict';
angular.module('DataAccessApp').controller('clientEditController',
['$scope', 'clientService', '$state', 'clientFormFactory', '$q', 'uniquePassportValidator', ClientEditController]);
function ClientEditController($scope, clientService, $state, formFactory, $q, uniquePassportValidator) {

    var vm = $scope;

    var _labelMap = {
        'edit': {
            title: 'client.editClient',
        },
        'create': {
            title: 'client.createClient',
        }
    };

    var _getLabels = function () {
        return _labelMap[$state.current.mode];
    };

    var _init = function (userModel) {

        var passportValidator = function (passport) {

            var deferred = $q.defer();
            var promise = deferred.promise;

            if ($state.current.mode === 'edit' && passport === userModel.passport) {
                deferred.resolve();
            }
            else {
                promise = uniquePassportValidator.validate(passport)
            }

            return promise;
        }

        vm.options = {
            backState: 'app.main.client.index',
            fields: formFactory.create(passportValidator),
            serviceMethods: {
                getById: clientService.getById,
                edit: clientService.update,
                create: clientService.create,
            },
            view: {
                breadcrumb: [
                        {
                            title: 'common.home',
                            sref: 'app.main.home'
                        },
                        {
                            title: 'client.client',
                            sref: 'app.main.client.index'
                        },
                ],
                labels: _getLabels(),
            },
        };
    }

    var preInitPromise = $state.current.mode === 'create'
        ? $q.when({})
        : clientService.getById($state.params.id)

    preInitPromise.then(_init);
}
