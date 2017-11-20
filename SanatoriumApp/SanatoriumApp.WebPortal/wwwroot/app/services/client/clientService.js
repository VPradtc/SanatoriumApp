'use strict';
angular.module('DataAccessApp').service('clientService',
['ngUrlSettings', 'baseService', ClientService]);

function ClientService(ngUrlSettings, baseService) {

    var api = ngUrlSettings.serverApiUri + 'api/client/';

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
        isUniquePassport: function (passport) {
            return baseService.callGet(api + 'IsUniquePassport', { passport: passport });
        },
    };
}
