demo.controller('userMakesController', function ($scope, $location, $routeParams, userService, makesService) {

    $scope.user = {};

    loadMakes();

    loadPreffered();

    function loadMakes() {
        makesService.getNonPrefferedMakes($routeParams.userId)
         .then(function (makes) {
             $scope.allMakesNonPreffered = makes;
         });
    };

    function loadPreffered() {
        makesService.getPrefferedMakes($routeParams.userId)
         .then(function (makes) {
             $scope.user.PrefferedManufacturers = makes;
         });
    };

    $scope.addModelToPrefferedList = function (make) {
        var index = $scope.allMakesNonPreffered.indexOf(make);
        if (index > -1) {
            $scope.allMakesNonPreffered.splice(index, 1);
        }

        $scope.user.PrefferedManufacturers.push(make);
    };
});