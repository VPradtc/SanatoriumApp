'use strict';
angular.module('DataAccessApp').service('bookingService',
['ngUrlSettings', 'baseService', BookingService]);

function BookingService(ngUrlSettings, baseService) {

    var api = ngUrlSettings.serverApiUri + 'api/booking/';

    return {
        getByPageUrl: api + 'GetByPage',
        getClientsUrl: ngUrlSettings.serverApiUri + 'api/client/GetAll',
        getRoomsUrl: ngUrlSettings.serverApiUri + 'api/room/GetAll',
        getById: function (id) {
            return baseService.callGet(api + 'GetById', { id: id })
                .then(model => {
                    model.startDate = new Date(model.startDate);
                    model.endDate = new Date(model.endDate);

                    return model;
                });
        },
        update: function (entity) {
            return baseService.callPost(api + 'Update', entity);
        },
        create: function (entity) {
            return baseService.callPost(api + 'Create', entity);
        },
        delete: function (id) {
            return baseService.callPost(api + 'Delete', id);
        },
        isVacant: function (entity) {
            return baseService.callGet(api + 'isVacant', entity);
        },
    };
}
