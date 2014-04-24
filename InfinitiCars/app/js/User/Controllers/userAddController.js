demo.controller('userAddController', function ($scope, $location, userService) {

    $scope.addUser = function (user) {
        userService.addUser(user)
            .then(function (data) {
                $location.url('/Users');
            });
    };
});