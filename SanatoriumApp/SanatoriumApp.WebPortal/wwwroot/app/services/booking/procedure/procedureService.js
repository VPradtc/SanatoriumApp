'use strict';
angular.module('DataAccessApp').service('procedureService',
['ngUrlSettings', 'baseService', ProcedureService]);

function ProcedureService(ngUrlSettings, baseService) {

    var api = ngUrlSettings.serverApiUri + 'api/ScheduledMedicalProcedure/';

    return {
        getByPageUrl: api + 'GetByPage',
        getMedicalProceduresUrl: ngUrlSettings.serverApiUri + 'api/MedicalProcedure/GetAll', 
        getUsersUrl: ngUrlSettings.serverApiUri + 'api/User/GetAll',
        getById: function (id) {
            return baseService.callGet(api + 'GetById', { id: id })
                .then(model => {
                    model.scheduledDate = new Date(model.scheduledDate);

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
    };
}
