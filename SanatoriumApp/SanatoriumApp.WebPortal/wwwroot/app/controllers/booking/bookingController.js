'use strict';
angular.module('DataAccessApp').controller('bookingController',
    ['$scope', 'bookingService', 'bookingModel', 'shortDateColumnTemplateFactory', BookingController]);

function BookingController($scope, bookingService, bookingModel, shortDateColumnTemplateFactory) {
    $scope.gridConfig = {
        grid: {
            getDataUrl: bookingService.getByPageUrl,
            model: bookingModel,
            columns: [
                {
                    field: 'clientName',
                    title: 'booking.client'
                },
                {
                    field: 'roomName',
                    title: 'booking.room'
                },
                {
                    field: 'startDate',
                    title: 'booking.startDate',
                    template: shortDateColumnTemplateFactory.create('startDate'),
                },
                {
                    field: 'endDate',
                    title: 'booking.endDate',
                    template: shortDateColumnTemplateFactory.create('endDate'),
                },
                {
                    type: 'action',
                    value: ['edit', 'delete'],
                },
            ]
        },
        delete: {
            text: 'booking.deleteThisBooking',
            confirmButtonText: 'common.delete',
            serviceMethod: bookingService.delete
        },

        createState: 'app.main.booking.create',
        editState: 'app.main.booking.edit',

        view: {
            title: 'booking.bookings',
            breadcrumb: [
                {
                    title: 'common.home',
                    sref: 'app.main.home'
                },
                {
                    title: 'booking.bookings',
                },
            ],
            buttons: [
                {
                    text: 'common.create',
                    state: 'app.main.booking.create'
                },
            ],
        }
    };
}

