demo.factory('makesService', function ($http, $q) {
    return {
        url: '/api/Make/',
        getMakes: function () {
            var deferred = $q.defer();
            $http({ method: 'get', url: this.url })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        },

        deleteMake: function (makeId) {
            var deferred = $q.defer();

            $http({ method: 'delete', url: this.url + makeId })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (reason) {
                    deferred.reject(reason);
                });

            return deferred.promise;
        },

        getPrefferedMakes: function (userId) {
            var deferred = $q.defer();
            $http({ method: 'get', url: '/api/Make/GetPrefferedModelsByUser/' + userId })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        },

        getNonPrefferedMakes: function (userId) {
            var deferred = $q.defer();
            $http({ method: 'get', url: '/api/Make/GetNonPrefferedMakesByUser/' + userId })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        },
    };
});