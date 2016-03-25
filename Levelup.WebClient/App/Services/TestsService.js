/// <reference path="../scripts/angular.js" />
/// <reference path="../App.js" />
Levelup.service('TestsService', ['$http', '$q', 'ConfigService', function ($http, $q, ConfigService) {
    var me = this;

    me.getAll = function () {
        return $q(function (resolve, reject) {
            $http.get(ConfigService.hostUrl + 'api/test')
            .then(function (response) {
                return resolve(response);
            },
            function (response) {
                return reject(response);
            });
        });

        
    };
}]);