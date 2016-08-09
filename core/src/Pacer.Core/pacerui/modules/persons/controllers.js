'use strict';

angular.module('Persons')

    .controller('PersonsController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {

                console.log("pacer data:"+pacerData);
                var personsData = pacerData;
                $scope.header1 = personsData.header.header1;
                $scope.header2 = personsData.header.header2;
                $scope.personsDetails = [];
                var isNatureOfSuitExist = false;
                for (var x in  personsData.queryResult){
                    var item = personsData.queryResult[x];
                    if (item.PartyName) {
                        $scope.personsDetails.push({
                            href: item.PartyName[0],
                            name: item.PartyName[1],
                            etc: item.PartyType
                        });
                    }else {
                        var record = { href: item.CaseNumber[0],
                            name: item.CaseNumber[1]};
                        record["Parties"] = item.Parties;
                        if (item.CaseFiledDate){
                            record["CaseFiledDate"] = item.CaseFiledDate;
                        }
                        if (item.CaseClosedDate != null){
                            record["CaseClosedDate"] = item.CaseClosedDate;
                        }
                        if (item.NatureOfSuit != null){
                            record["NatureOfSuit"] = item.NatureOfSuit;
                            isNatureOfSuitExist = true;
                        }
                        $scope.personsDetails.push(record);
                    }
                }
                $scope.isNatureOfSuitExist = isNatureOfSuitExist;
                $scope.billing = personsData.billing;

                $scope.fetchCase = function (perlScript)
                {
                    perlScript  = perlScript.split('?').pop();
                    PacerCoreService.storeData('perlScript',perlScript);
                    $location.path("/case");
                }
            }  ]);
