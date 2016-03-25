/// <reference path="../scripts/angular.js" />
/// <reference path="../App.js" />
Levelup.service('AuthService', ['$http', '$q', 'TokenService', 'UserService', '$location', 'ConfigService', function ($http, $q, TokenService, UserService, $location, ConfigService) {
    var me = this;

    me.login = function (User) {
        return $q(function (resolve, reject) {
            $http.post(ConfigService.hostUrl + 'api/Account/Login', User)
            .then(function (response) {
                return TokenService.setToken(response.data);
            }, function (response) {
                return reject(response);
            })
            .then(function (response) {
                return UserService.getInfo();
            }, function (response) {
                return reject(response);
            })
            .then(function (response) {
                return resolve(true);
            }, function (response) {
                return reject(response);
            });
        });
    }

    me.forgotPassword = function (User) {
        return $q(function (resolve, reject) {
            User.RedirectUrl = ConfigService.myUrl + '#/resetPassword';
            $http.post(ConfigService.hostUrl + 'api/Account/ForgotPassword', User)
            .then(function (response) {
                return resolve(true);
            }, function (response) {
                return reject(response);
            });
        });
    }

    me.resetPassword = function (User) {
        return $q(function (resolve, reject) {
            $http.post(ConfigService.hostUrl + 'api/Account/ResetPassword', User)
            .then(function (response) {
                return resolve(true);
            }, function (response) {
                return reject(response);
            });
        });
    }

    me.register = function (User) {
        return $q(function (resolve, reject) {
            User.RedirectUrl = ConfigService.myUrl + '#/login';
            $http.post(ConfigService.hostUrl + 'api/Account/Register', User)
            .then(function (response) {
                return resolve(response);
            }, function (response) {
                return reject(response);
            });
        });
    }

    me.confirmEmail = function (User) {
        return $q(function (resolve, reject) {
            $http.post(ConfigService.hostUrl + 'api/Account/ConfirmEmail', User)
            .then(function (response) {
                return resolve(response);
            }, function (response) {
                return reject(response);
            });
        });
    }
}]);