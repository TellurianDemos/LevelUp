/// <reference path="../scripts/angular.js" />
/// <reference path="../App.js" />
Levelup.controller('AuthMiddlewareController', ['$scope', '$location', 'TokenService', 'UserService', 'Notification', 'ConfigService', function ($scope, $location, TokenService, UserService, Notification, ConfigService) {
    $scope.Data = { IsAuthorized: null, User: null };
    $scope.Data.IsAuthorized = TokenService.IsAuthorized;
    $scope.Data.User = UserService.User;

    $scope.logout = function () {
        TokenService.removeToken()
            .then(function (response) {
                $location.path('/login');
            }, function (response) {
                Notification.error('Logout failed!');
            });
    }
}]);