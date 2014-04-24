demo.controller('makeAddController', function ($scope, $location, makeService) {
    
    $scope.addMake = function (make) {
        
        makeService.addMake(make)
            .then(function (data) {
                $location.url('/Makes');
            });
    };

    $scope.addModelToMake = function (make) {

        if (make.Models == undefined) {
            make.Models = [];
        }

        var currentModel = {
            Name: make.ModelName,
            Description: make.ModelDescription
        };

        $scope.make.Models.push(currentModel);

        $scope.make.ModelDescription = [];

        $scope.make.ModelName = [];
    };
    
    //$.getJSON("/api/Model/", function (result) {
    //    var options = $("#options");
    //    $.each(result, function () {
    //        options.append($("<option />").val(this.Name).text(this.Description));
    //    });
    //});
});