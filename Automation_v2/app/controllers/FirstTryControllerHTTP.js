//angular.module('AutomationApp')
//    .controller('FirstTryController', function ($scope, $location, TestSuitesService) {
//        TestSuitesService.GetById().then(function (d) {
//            $scope.items = d;
//            $scope.test = "MEOW";
//            console.log(d);
//        });
//    });

//angular.module('AutomationApp')
//    .controller('FirstTryControllerHTTP', function ($scope, $location, TestSuitesHTTP) {
//        TestSuitesHTTP.Get().then(function (d) {
//            $scope.items = d;
//        });
//    });


angular.module('AutomationApp')
    .controller('FirstTryControllerHTTP', function ($http) {
        var app = this;
        $scope.test = "Hello Kitty";
        $http.get('/api/listTestSuites')
        .success(function(data){
            app.items = data;
        })
    });


//I've created a service that calls $http (not $resource) and to get the value to the controller.
//It took some time and i found a lot of example but not exactly what i needed. 
//Maybe this will help someone:


//The service:


//angular.module('myApp.services', []).
//    service('Activities', function($http, $q) {
//        this.get = function(from, to){
//            var deferred = $q.defer();
//            var url = 'user/activities?from='+from+'&to='+to;
//            $http.get(url).success(function(data, status) {
//                // Some extra manipulation on data if you want...
//                deferred.resolve(data);
//            }).error(function(data, status) {
//                deferred.reject(data);
//            });


//            return deferred.promise;
//        }
//    }
//);


//The call inside the controller (don't forget to DI the service in the controller's parameters):


//var promise = Activities.get(now, monthAgo);
//promise.then(
//    function(activities){$scope.transactions = activities;}
//    ,function(reason){alert('Failed: ' + reason);}
// );
