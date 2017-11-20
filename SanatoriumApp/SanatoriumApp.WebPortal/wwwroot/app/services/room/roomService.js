'use strict';
angular.module('DataAccessApp').service('roomService',
['ngUrlSettings', 'baseService', RoomService]);

function RoomService(ngUrlSettings, baseService) {

    var api = ngUrlSettings.serverApiUri + 'api/room/';

    return {
        getByPageUrl: api + 'GetByPage',
        getById: function (id) {
            return baseService.callGet(api + 'GetById', { id: id });
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
    };
}
