angular.module('DataAccessApp').factory('vacantBookingValidator',
    ['$q', 'bookingService', vacantBookingValidator]);

function vacantBookingValidator($q, bookingService) {

    var _create = function (entitySelector) {

        var _validate = function () {

            var entity = entitySelector();

            var deferred = $q.defer();

            bookingService.isVacant(entity)
            .then(
                function (isVacant) {
                    isVacant
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

    return {
        create: _create,
    }
}
