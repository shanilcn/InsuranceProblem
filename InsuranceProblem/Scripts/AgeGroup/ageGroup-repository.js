(function () {

    var ageGroupFactory = function ($http, $q) {
        var factory = {};

        factory.get = function () {
            var deferred = $q.defer();
            $http.get('/AgeGroup').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        };

        factory.save = function (ageGroup) {
            var deferred = $q.defer();
            $http.post('/AgeGroup/Save', ageGroup)
                .success(function () { deferred.resolve(); })
                .error(function () { deferred.reject(); });
            return deferred.promise;
        };

        return factory;
    }

    ageGroupFactory.$inject = ['$http', '$q'];

    insuranceProblemModule.factory("ageGroupVisitorsRepository", ageGroupFactory);

}());