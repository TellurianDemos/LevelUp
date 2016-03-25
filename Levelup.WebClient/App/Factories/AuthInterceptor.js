/// <reference path="C:\Users\user\Documents\Visual Studio 2015\Projects\Levelup\levelup\Levelup.WebClient\scripts/angular.js" />
Levelup.factory('AuthInterceptor', ['$q', '$location', 'TokenService', '$injector', function ($q, $location, TokenService, $injector) {
    return {
        response: function (response) {
            return response;
        },

        responseError: function (response) {
            return $q(function (resolve, reject) {
                var Notification = $injector.get('Notification');
                if (response.status === 401) {
                    Notification.warning(response.data.Message);
                    TokenService.removeToken()
                    .then(function (response) {
                        $location.path('/login');
                        return reject(response);
                    });
                }
                if (response.status === 400) {
                    return reject(response);
                }
                return resolve(response);
            });

            
        },



        request: function (request) {
            TokenService.getHeader()
            .then(function (header) {
                request.headers['Authorization'] = header;
                return $q.resolve(request);
            }, function (noheader) {
                return $q.reject(request);

            });
            return $q.when(request);
        }
    }
}]);