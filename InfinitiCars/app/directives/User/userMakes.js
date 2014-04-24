'use strict';

demo.directive('userMakes', function () {
    return {
        ///'A' - only matches attribute name
        ///'E' - only matches element name
        ///'AE' - matches either attribute or element name
        restrict: 'C',
        templateUrl: 'app/Templates/User/UserMakes.html',
        replace: true,
        controller: function ($scope, makesService, $routeParams) {

            $scope.user = {};

            loadMakes();

            loadPreffered();

            function loadMakes() {
                if ($routeParams.userId == undefined) {

                    makesService.getMakes()
                       .then(function (makes) {
                           $scope.allMakesNonPreffered = makes;
                       });
                }
                else {

                    makesService.getNonPrefferedMakes($routeParams.userId)
                        .then(function (makes) {
                            $scope.allMakesNonPreffered = makes;
                        });
                }
            };

            function loadPreffered() {

                if ($routeParams.userId == undefined) {
                    $scope.user.PrefferedManufacturers = [];
                } else {

                    makesService.getPrefferedMakes($routeParams.userId)
                        .then(function (makes) {
                            $scope.user.PrefferedManufacturers = makes;
                        });
                }
            };

            $scope.addModelToPrefferedList = function (make) {
                var index = $scope.allMakesNonPreffered.indexOf(make);
                if (index > -1) {
                    $scope.allMakesNonPreffered.splice(index, 1);
                }

                $scope.user.PrefferedManufacturers.push(make);
            };
        },

        link: function ($scope, $routeParams) {
        }
    };
});
