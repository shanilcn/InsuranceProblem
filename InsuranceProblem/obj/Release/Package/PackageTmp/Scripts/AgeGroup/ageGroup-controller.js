'use strict';
insuranceProblemModule.controller("AgeGroupVisitorsController", function ($scope, ageGroupVisitorsRepository, $location) {
    ageGroupVisitorsRepository.get().then(
        function (ageGroupVistors) { $scope.ageGroupVistors = ageGroupVistors; }
        );

    $scope.save = function (ageGroup) {
        $scope.error = false;
        ageGroupVisitorsRepository.save(ageGroup)
            .then(
            function () { $location.url('/InsuranceProblem/AgeGroupVisits'); },
            function () { $scope.error = true; }
            );
    }
})