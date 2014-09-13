'use strict';
insuranceProblemModule.controller("CalculateController", function ($scope, calculateRepository, $location) {
    //calculateRepository.get().then(
    //    function (ageGroupVistors) { $scope.ageGroupVistors = ageGroupVistors; }
    //    );

    $scope.calculate = function (input) {
        $scope.error = false;
        $scope.success = false;
        $scope.result = "";
        calculateRepository.calculate(input)
            .then(function (data) {
                $scope.success = true;
                $scope.result = data.result;
            },
            function () { $scope.error = true; }
            );
    }
})