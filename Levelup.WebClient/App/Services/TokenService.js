/// <reference path="../scripts/angular.js" />
/// <reference path="../App.js" />
Levelup.service('TokenService', ['$location', '$q', function ($location, $q) {
    var me = this;

    me.Token = { value: {} };
    me.IsAuthorized = { value: false };
    
    //init func
    (me.updateToken = function () {
        var token = localStorage.getItem("Token");
        if (token !== null) {
            me.Token.value = JSON.parse(token);
            me.IsAuthorized.value = true;
        }

    })();

    //check on exist
    me.IsExist = function () {
        return $q(function (resolve, reject) {
            var token = localStorage.getItem("Token");
            if (token === null) {
                me.IsAuthorized.value = false;
                return reject({ data: { Message: 'Token does not exist' } });
            }

            me.Token.value = JSON.parse(token);
            return resolve(true);
        });
    }

    //set token
    me.setToken = function (token) {
        return $q(function (resolve, reject) {
            if (!token)
                return reject({ data: { Message: 'Token is null' } });
            //validation token
            var isValid = true;
            if (!token.hasOwnProperty('access_token')) isValid = false;
            if (!token.hasOwnProperty('token_type')) isValid = false;
            if (!token.hasOwnProperty('expires_in')) isValid = false;
            if (!token.hasOwnProperty('userName')) isValid = false;
            if (!token.hasOwnProperty('.issued')) isValid = false;
            if (!token.hasOwnProperty('.expires')) isValid = false;

            if (!isValid)
                return reject({ data: { Message: "Invalid token object!" } });
            //set localStorage item
            localStorage.setItem('Token', JSON.stringify(token));
            me.Token.value = token;
            me.IsAuthorized.value = true;
            return resolve(true);
        });


    }

    //remove token
    me.removeToken = function () {
        return $q(function (resolve, reject) {
            localStorage.removeItem('Token');
            me.Token.value = {};
            me.IsAuthorized.value = false;
            resolve(true);
        });
    }

    //get token
    me.getToken = function () {
        return $q(function (resolve, reject) {
            resolve(me.Token.value);
        });
    }

    //get header
    me.getHeader = function () {
        return $q(function (resolve, reject) {
            me.getToken().then(function (response) {
                var token = response;
                if (!token.token_type || !token.access_token)
                    return reject({ data: { Message: 'Token is empty' }});
                return resolve(token["token_type"] + " " + token["access_token"]);

            });
        });
    }

    //check on exist, if not - redirect
    me.checkToken = function () {
        return $q(function (resolve, reject) {
            me.IsExist()
            .then(function (response) {
                return response;
            }, function (response) {
                $location.path('/login');
            });
        });
        
    }

}]);