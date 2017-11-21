'use strict';
angular.module('DataAccessApp').controller('bookingEditController',
['$scope', 'bookingService', '$state', 'bookingFormFactory', '$q', 'vacantBookingValidator', BookingEditController]);
function BookingEditController($scope, bookingService, $state, formFactory, $q, vacantBookingValidator) {

    var vm = $scope;

    var _labelMap = {
        'edit': {
            title: 'booking.editBooking',
        },
        'create': {
            title: 'booking.createBooking',
        }
    };

    var _getLabels = function () {
        return _labelMap[$state.current.mode];
    };

    var _init = function (entity) {

        var validator = vacantBookingValidator.create(() => vm.options.entity || {});

        var validatorFunction = validator.validate;

        vm.options = {
            backState: 'app.main.booking.index',
            fields: formFactory.create(validatorFunction),
            serviceMethods: {
                getById: bookingService.getById,
                edit: bookingService.update,
                create: bookingService.create,
            },
            view: {
                breadcrumb: [
                        {
                            title: 'common.home',
                            sref: 'app.main.home'
                        },
                        {
                            title: 'booking.booking',
                            sref: 'app.main.booking.index'
                        },
                ],
                labels: _getLabels(),
            },
        };
    }

    var preInitPromise = $state.current.mode === 'create'
        ? $q.when({})
        : bookingService.getById($state.params.id)

    preInitPromise.then(_init);
}

