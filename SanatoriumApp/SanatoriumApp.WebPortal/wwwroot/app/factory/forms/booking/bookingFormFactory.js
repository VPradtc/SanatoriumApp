angular.module('DataAccessApp').factory('bookingFormFactory',
    ['bookingService', BookingFormFactory]);

function BookingFormFactory(bookingService) {

    var _create = function (vacantBookingValidator) {

        var _fields = [
            {
                field: 'startDate',
                label: 'booking.startDate',
                attrs: {
                    type: 'date',
                    name: 'startDate',
                    required: '',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'booking.startDateIsRequired',
                    },
                ],
            },
            {
                field: 'clientId',
                label: 'booking.client',
                optionLabel: 'booking.selectClient',
                attrs: {
                    type: 'select',
                    name: 'clientId',
                    required: '',
                },
                dataSource: {
                    static: false,
                    data: bookingService.getClientsUrl,
                },
                options: {
                    dataTextField: 'name',
                    dataValueField: 'identifier',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'booking.clientIsRequired'
                    },
                ],
            },
            {
                field: 'roomId',
                label: 'booking.room',
                optionLabel: 'booking.selectRoom',
                attrs: {
                    type: 'select',
                    name: 'roomId',
                    required: '',
                },
                dataSource: {
                    static: false,
                    data: bookingService.getRoomsUrl,
                },
                options: {
                    dataTextField: 'name',
                    dataValueField: 'identifier',
                },
                validators: [
                    {
                        async: true,
                        validation: 'vacant',
                        validator: vacantBookingValidator,
                    }
                ],
                messages: [
                    {
                        validation: 'required',
                        text: 'booking.roomIsRequired'
                    },
                    {
                        validation: 'vacant',
                        text: 'booking.roomIsInUse',
                    },
                ],
            },
            {
                field: 'endDate',
                label: 'booking.endDate',
                attrs: {
                    type: 'date',
                    name: 'endDate',
                    required: '',
                },
                messages: [
                    {
                        validation: 'required',
                        text: 'booking.endDateIsRequired',
                    },
                ],
            },
        ];

        return _fields;
    }

    return {
        create: _create,
    }
}
