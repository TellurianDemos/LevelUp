/// <reference path="../scripts/angular.js" />
/// <reference path="../App.js" />
Levelup.controller('AuthController', ['$scope', '$q', '$location', 'AuthService', 'TokenService', '$routeParams', 'Notification', function ($scope, $q, $location, AuthService, TokenService, $routeParams, Notification) {

    $scope.succeeded = true;

    $scope.loadResetPassword = function () {
        if (!$routeParams.code || !$routeParams.email) {
            console.log('No data!');
            return;
        }
        $scope.ResetModel = { Code: null, Email: null, Password: null, ConfirmPassword: null };
        $scope.ResetModel.Code = $routeParams.code;
        $scope.ResetModel.Email = $routeParams.email;
    }

    $scope.loadConfirmation = function () {
        if (!$routeParams.token || !$routeParams.id) {
            return;
        }
        var User = { Id: $routeParams.id, Token: $routeParams.token };
        AuthService.confirmEmail(User)
        .then(function (response) {
            console.log(response);
            if (response.data)
                Notification.success(response.data);
        }, function (response) {
            console.log(response);
            if (response.data)
                Notification.error(response.data.Message);
        });
    }

    $scope.login = function (User) {
        if (!$scope.LoginForm.$valid) {
            Notification.warning('Form is invalid!');
            return;
        }
        $scope.succeeded = false;
        AuthService.login(User)
        .then(function (response) {
            Notification.success('Login succeded');
            $location.path('/');
            $scope.succeeded = true;
        },
        function (response) {
            
            if (response.data.ModelState) {
                if (response.data.ModelState['model.Email'])
                    response.data.ModelState['model.Email'].forEach(function (err) {
                        Notification.warning(err);
                    });
                if (response.data.ModelState['model.Password'])
                    response.data.ModelState['model.Password'].forEach(function (err) {
                        Notification.warning(err);
                    });
            }
            
            Notification.error(response.data.Message);
            $scope.succeeded = true;
        });
    }

    $scope.forgotPassword = function (User) {
        if (!$scope.ForgotPasswordForm.$valid) {
            Notification.warning('Form is invalid!');
            return;
        }
        $scope.succeeded = false;
        AuthService.forgotPassword(User)
        .then(function () {
            Notification.success("To reset password please check you email");
            $location.path('/login');
            $scope.succeeded = true;
        },
        function (response) {
            Notification.error(response.data.Message);
            $scope.succeeded = true;
        });
    }

    $scope.resetPassword = function () {
        if (!$scope.ResetPasswordForm.$valid) {
            Notification.warning('Form is invalid!');
            return;
        }
        $scope.succeeded = false;
        AuthService.resetPassword($scope.ResetModel)
        .then(function () {
            Notification.success("Password successfully changed");
            $location.search(''); //clean url
            $location.path('/login');
            $scope.succeeded = true;
        },
        function (response) {
            Notification.error(response.data.Message);
            $scope.succeeded = true;
        });
    }

    $scope.register = function (User) {
        if (!$scope.RegisterForm.$valid) {
            Notification.warning('Form is invalid!');
            return;
        }
        $scope.succeeded = false;
        AuthService.register(User)
        .then(function (response) {
            Notification.success("Sign up succeeded, please check your email to confirm account");
            $location.path('/login');
            $scope.succeeded = true;
        },
        function (response) {
            Notification.error(response.data.Message);
            $scope.succeeded = true;
        });
    }
}]);