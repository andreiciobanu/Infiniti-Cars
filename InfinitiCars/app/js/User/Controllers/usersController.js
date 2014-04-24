demo.controller('usersController', function ($scope, $location, usersService) {

    $scope.users = [];

    loadUsers();

    $scope.deleteUser = function (id) {
        usersService.deleteUser(id)
                .then(function (data) {
                    loadUsers();
                });
    };

    function loadUsers() {
        usersService.getUsers()
                .then(function (data) {
                    $scope.users = data;
                });
    };
});