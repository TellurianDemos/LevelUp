/// <reference path="../scripts/angular.js" />
/// <reference path="../Services/TokenService.js" />
/// <reference path="../App.js" />
Levelup.controller('TestsController', ['$scope', 'TestsService', 'TokenService', 'Notification', function ($scope, TestsService, TokenService, Notification) {
    //filter
    TokenService.checkToken();

    //init
    TestsService.getAll()
    .then(function (response) {
        $scope.tests = response.data;
    }, function (response) {
        Notification.error(response.data.Message);
    });
}]);