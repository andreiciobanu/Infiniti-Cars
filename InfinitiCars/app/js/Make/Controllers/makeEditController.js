demo.controller('makeEditController', function ($scope, $location, $routeParams, makeService) {

    $scope.make = {};

    makeService.getMake($routeParams.makeId)
        .then(function (data) {
            $scope.make = data;
        });

    $scope.editMake = function (make) {
        makeService.editMake(make).then(function (data) {
            $location.url('/Makes');
        });
    };

    //$.getJSON("/api/Make/GetModelsForMake/" + $routeParams.makeId, function (result) {
    //    var options = $("#options");
    //    $.each(result, function () {
    //        options.append($("<option />").val(this.Name).text(this.Description));
    //    });
    //});
});