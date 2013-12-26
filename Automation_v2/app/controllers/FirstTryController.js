// CONTROLLER

angular.module('AutomationApp')
    .controller('FirstTryController', function ($scope, TestSuites) {
        $scope.items = {};
        TestSuites.query(function (response) {
            $scope.items = response;
        });
    });