demo.controller('makesController', function ($scope, $location, makesService) {

    $scope.makes = [];
    
    init();

    $scope.deleteMake = function (id) {
        makesService.deleteMake(id)
                .then(function (data) {
                    loadMakes();
                });
    };

    function init() {
        loadMakes();
    };

    function loadMakes() {
        makesService.getMakes().then(function (data) {
            $scope.makes = data;
        });
    };

});