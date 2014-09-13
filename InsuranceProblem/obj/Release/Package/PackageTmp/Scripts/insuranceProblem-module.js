var insuranceProblemModule = angular.module("insuranceProblemModule", [])
    .config(function($routeProvider, $locationProvider) {
        $routeProvider.when('/InsuranceProblem/AgeGroupVisits', { templateUrl: '/templates/agegroup-visitors.html', controller: 'AgeGroupVisitorsController' });
        $routeProvider.when('/InsuranceProblem/CalculateMixture', { templateUrl: '/templates/calculate.html', controller: 'CalculateController' });
        $routeProvider.when('/InsuranceProblem/AddAgeGroupVisitors', { templateUrl: '/templates/create-agegroup-visitors.html', controller: 'AgeGroupVisitorsController' });

        $locationProvider.html5Mode(true);
    })