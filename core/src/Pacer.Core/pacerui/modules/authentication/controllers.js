'use strict';
 
angular.module('Authentication')
 
.controller('LoginController',
    ['$scope', '$rootScope', '$location', 'AuthenticationService',
    function ($scope, $rootScope, $location, AuthenticationService) {
        AuthenticationService.ClearCredentials();

        $scope.username = 'tr1234';
        $scope.password = 'Pass!234';

        $scope.login = function () {
            $scope.dataLoading = true;
            AuthenticationService.login($scope.username, $scope.password, function(response) {
                if(response.success) {
                    AuthenticationService.SetCredentials($scope.username, $scope.password);
                    $location.path('/home');
                } else {
                    $scope.error = response.message;
                    $scope.dataLoading = false;
                }
            });
            console.log ("authentication completed");
        };

    }]);