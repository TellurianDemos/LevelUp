/// <reference path="C:\Users\user\Documents\Visual Studio 2015\Projects\Levelup\levelup\Levelup.WebClient\scripts/angular-route.js" />
/// <reference path="C:\Users\user\Documents\Visual Studio 2015\Projects\Levelup\levelup\Levelup.WebClient\scripts/angular-ui-notification/angular-ui-notification.js" />
/// <reference path="C:\Users\user\Documents\Visual Studio 2015\Projects\Levelup\levelup\Levelup.WebClient\scripts/angular.js" />
var Levelup = angular.module('Levelup', ['ngRoute', 'ui.bootstrap', 'ui-notification']);

Levelup.config(['$routeProvider', '$locationProvider', '$httpProvider', 'NotificationProvider', function ($routeProvider, $locationProvider, $httpProvider, NotificationProvider) {
    $routeProvider
        .when('/', {
            templateUrl: './App/Partials/Home.html',
            controller: 'HomeController'
        })
        .when('/tests', {
            templateUrl: './App/Partials/Tests.html',
            controller: 'TestsController'
        })
        .when('/departments', {
            templateUrl: './App/Partials/Departments.html',
            controller: 'DepartmentsController'
        })
        .when('/register', {
            templateUrl: './App/Partials/Register.html',
            controller: 'AuthController'
        })
        .when('/forgotPassword', {
            templateUrl: './App/Partials/ForgotPassword.html',
            controller: 'AuthController'
        })
        .when('/resetPassword', {
            templateUrl: './App/Partials/ResetPassword.html',
            controller: 'AuthController'
        })
        .when('/login', {
            templateUrl: './App/Partials/Login.html',
            controller: 'AuthController'
        })
        .when('/error', {
            templateUrl: './App/Partials/FunError.html',
            controller: ''
        })
        .otherwise({
            redirectTo: '/error'
        });

    $httpProvider.interceptors.push('AuthInterceptor');

    NotificationProvider.setOptions({
        delay: 5000,
        startTop: 80,
        startRight: 20,
        verticalSpacing: 20,
        horizontalSpacing: 20,
        positionX: 'right',
        positionY: 'top'
    });
}]);
