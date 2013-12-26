
var app = angular.module('AutomationApp', ['ngRoute', 'ngResource']);

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/list', {
            templateUrl: 'app/views/firsttry.html',
            controller: 'FirstTryController',
            resolve: {
                delay: function ($q, $timeout) {
                    var delay = $q.defer();
                    $timeout(delay.resolve, 500);
                    return delay.promise;
                }
            }
        })
        .when('/listHTTP', {
            templateUrl: 'app/views/firsttryHTTP.html',
            controller: 'FirstTryControllerHTTP',
            resolve: {
                delay: function ($q, $timeout) {
                    var delay = $q.defer();
                    $timeout(delay.resolve, 100);
                    return delay.promise;
                }
            }
        })
        .otherwise({ redirectTo: '/index.html' });
});