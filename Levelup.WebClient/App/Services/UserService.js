/// <reference path="../scripts/angular.js" />
/// <reference path="../App.js" />
Levelup.service('UserService', ['$http', '$q', 'TokenService', 'ConfigService', function ($http, $q, TokenService, ConfigService) {
    var me = this;

    me.User = { Email: {}, UserName: {}, FullName: {}, IsAdmin: {} };

    //init func
    (me.getInfo = function () {
        return $q(function (resolve, reject) {
            TokenService.IsExist()
            .then(function (response) {
                return $http.get(ConfigService.hostUrl + 'api/Account/UserInfo');
            }, function (response) {
                return reject(response);
            })
            .then(function (response) {
                if (!response || !response.data)
                    return reject('No response');
                me.User.Email = response.data.Email;
                me.User.UserName = response.data.UserName;
                me.User.FullName = response.data.FullName;
                me.User.IsAdmin = response.data.IsAdmin;
                return resolve(response);

            }, function (response) {
                return reject(response);
            });

        });
    })();

}]);