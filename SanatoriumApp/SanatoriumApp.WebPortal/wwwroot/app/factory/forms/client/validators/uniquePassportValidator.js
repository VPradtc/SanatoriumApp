angular.module('DataAccessApp').factory('uniquePassportValidator',
    ['$q', 'clientService', uniquePassportValidator]);

function uniquePassportValidator($q, clientService) {

    var _validate = function (passport) {

        var deferred = $q.defer();

        clientService.isUniquePassport(passport)
        .then(
            function (isUnique) {
                isUnique
                    ? deferred.resolve()
                    : deferred.reject();
            },
            function (error) {
                deferred.reject();
            });

        return deferred.promise;
    }

    return {
        validate: _validate,
    }
}
