demo.factory('userService', function ($http, $q) {
    return {
        addUser: function (user) {
            var deferred = $q.defer();
            $http({ method: 'post', url: '/api/User/', data: user })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        },

        editUser: function (user) {
            var deferred = $q.defer();
            $http({ method: 'put', url: '/api/User/' + user.Id, data: user })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        },

        getUser: function (id) {
            var deferred = $q.defer();
            $http({ method: 'get', url: '/api/User/Get/' + id })
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