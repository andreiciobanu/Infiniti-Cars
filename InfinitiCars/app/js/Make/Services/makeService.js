demo.factory('makeService', function ($http, $q) {
    return {
        addMake: function (make) {
            var deferred = $q.defer();
            $http({ method: 'post', url: '/api/Make/',data: make})
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        },
        editMake: function (make) {
            var deferred = $q.defer();
            $http({ method: 'put', url: '/api/Make/' + make.Id, data: make })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        },
        getMake: function (id) {
            var deferred = $q.defer();
            $http({ method: 'get', url: '/api/Make/Get/' + id})
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }
    };
});