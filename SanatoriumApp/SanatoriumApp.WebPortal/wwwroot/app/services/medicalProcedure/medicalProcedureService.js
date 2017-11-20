'use strict';
angular.module('DataAccessApp').service('medicalProcedureService',
['ngUrlSettings', 'baseService', MedicalProcedureService]);

function MedicalProcedureService(ngUrlSettings, baseService) {

    var api = ngUrlSettings.serverApiUri + 'api/medicalProcedure/';

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
