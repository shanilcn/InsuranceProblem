(function () {
    var calculateFactory = function ($http, $q) {
        var factory = {};
        
        factory.calculate = function (input) {
            var deferred = $q.defer();

            $http.post('/CalculateMixture/Calculate', input)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function () { deferred.reject(); });
            
            return deferred.promise;
        };

        return factory;
    }

    calculateFactory.$inject = ['$http', '$q'];

    insuranceProblemModule.factory("calculateRepository", calculateFactory);

}());