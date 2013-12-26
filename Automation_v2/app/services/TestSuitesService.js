// SERVICE

angular.module('AutomationApp')
    .factory('TestSuites', function ($resource) {
        return $resource('/api/listTestSuites/:TestSuiteId',
            { TestSuiteId: '@TestSuiteId' },
            { query: {
                method: 'GET',
                params: {},
                isArray: false
                }
            });
    });