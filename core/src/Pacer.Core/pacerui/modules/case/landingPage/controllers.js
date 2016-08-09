'use strict';

angular.module('LandingPage')

    .controller('LandingPageController',
        ['$scope', '$rootScope', '$location', 'PacerCoreService','pacerData',
            function ($scope, $rootScope, $location,PacerCoreService,pacerData) {

                console.log("LandingPageController:pacer data:"+pacerData);
                if (pacerData.header){
                    $scope.caseHeader = pacerData.header;
                }else if (pacerData.header1) {
                    $scope.caseHeader = pacerData.header1;
                }else{
                    $scope.caseHeader = pacerData;
                }

            }  ]);
