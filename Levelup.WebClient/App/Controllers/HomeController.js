/// <reference path="../Services/TokenService.js" />
/// <reference path="../scripts/angular.js" />
/// <reference path="../App.js" />
Levelup.controller('HomeController', ['$scope', 'HomeService', 'TokenService', function ($scope, HomeService, TokenService) {
    //filter
    TokenService.checkToken();


}]);