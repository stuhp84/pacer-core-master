'use strict';

angular.module('DocketReport')

    .controller('DocketReportController',
        ['$scope', '$rootScope', '$location', 'PacerCoreService','pacerData',
            function ($scope, $rootScope, $location,PacerCoreService,pacerData) {

                console.log("Controller:pacer data:"+pacerData);
                $scope.pacerData = pacerData;
            }  ]);
