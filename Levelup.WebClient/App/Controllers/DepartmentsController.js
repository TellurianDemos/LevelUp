/// <reference path="../scripts/angular.js" />
/// <reference path="../App.js" />
Levelup.controller('DepartmentsController', ['$scope', 'DepartmentsService', 'TokenService', 'Notification', function ($scope, DepartmentsService, TokenService, Notification) {
    //filter
    TokenService.checkToken();


    //init
    DepartmentsService.getAll()
    .then(function (response) {
        $scope.departments = response.data;
    }, function (response) {
        Notification.error(response.data.Message);
    });
}]);