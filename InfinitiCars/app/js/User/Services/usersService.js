demo.factory('usersService', function ($http, $q) {
    return {
        url: '/api/User/',
        getUsers: function () {
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
        deleteUser: function (userId) {
            var deferred = $q.defer();

            $http({ method: 'delete', url: this.url + userId })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (reason) {
                    deferred.reject(reason);
                });

            return deferred.promise;
        }
    };
});