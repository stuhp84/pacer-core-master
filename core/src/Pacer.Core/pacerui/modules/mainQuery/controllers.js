'use strict';

angular.module('billing', []);

angular.module('MainQuery',['ngAnimate', 'ui.bootstrap','billing'])

    .controller('MainQueryController',
        ['$scope', '$rootScope', '$location', '$filter','AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, $filter,AuthenticationService,PacerCoreService,pacerData) {

                console.log("MainQueryController is on");
                $scope.dateselect = new Date();
                console.log("pacer data:"+pacerData);
                $scope.naturesuit = pacerData.MainFormSelectOptionValues.nature_suit;
                $scope.causeaction = pacerData.MainFormSelectOptionValues.cause_action;
                $scope.CaseQuery = {};

                $scope.getPersons= function () {
                    $scope.CaseQuery.CGIPerl = pacerData.MainFormForm.action;
                    PacerCoreService.storeData('CaseQueryData',$scope.CaseQuery);
                    var allFormFields = {};
                    var allFields = pacerData.MainFormForm.MainFormSelectFields.concat(pacerData.MainFormForm.MainFormNonSelectFields);
                    for (var x in allFields){
                        var nextf = allFields[x];
                        allFormFields[nextf.fieldName] = "";
                    }
                    var isLongForm = false;
                    var isCaseNumSearch = false;
                    for (var x in $scope.CaseQuery){
                        var nextElem = $scope.CaseQuery[x];
                        console.log ("nextElem:"+nextElem+":"+(nextElem instanceof Date));
                        
                        if (nextElem instanceof Date) {
                            $scope.CaseQuery[x] = $filter('date')(nextElem, 'MM/dd/yyyy');
                            isLongForm = true;
                        }else if (x == "case_num"){
                            isCaseNumSearch = true;
                        }
                        allFormFields[x] = $scope.CaseQuery[x];
                    }
                    if (isCaseNumSearch){
                        PacerCoreService.storeData('CaseQueryData',allFormFields);
                        $location.path("/directcase");
                    }else {
                        allFormFields['isLongForm'] = isLongForm;
                        PacerCoreService.storeData('CaseQueryData',allFormFields);
                        if (isLongForm)
                            $location.path("/getPersonsLong");
                        else
                            $location.path("/getPersonsShort");
                    }

                }

                $scope.getPersonsOld = function ()
                {
                   PacerCoreService.storeData('CaseQueryData',$scope.CaseQuery);
                   $location.path("/getPersons");
                }


                $scope.clear = function() {
                    $scope.CaseQuery.filled_to = null;
                    $scope.CaseQuery.filled_from = null;
                    $scope.CaseQuery.lastentry_from = new Date();
                    $scope.CaseQuery.lastentry_to = new Date();
                };

                $scope.dateOptions = {
                    dateDisabled: disabled,
                    formatYear: 'yy',
                    maxDate: new Date(2020, 5, 22),
                    //We won't restrict any min date. Default is null
                    //minDate: new Date(),//disabled
                    startingDay: 1
                };

                // Disable weekend selection
                function disabled(data) {
                    var date = data.date,
                        mode = data.mode;
                    return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
                }

                $scope.open1 = function() {
                    $scope.popup1.opened = true;
                };

                $scope.open2 = function() {
                    $scope.popup2.opened = true;
                };

                $scope.open3 = function() {
                    $scope.popup3.opened = true;
                };

                $scope.open4 = function() {
                    $scope.popup4.opened = true;
                };


                $scope.setDate = function(year, month, day) {
                    $scope.dt = new Date(year, month, day);
                };


                $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd/MM/yyyy', 'shortDate'];
                $scope.format = $scope.formats[2];
                $scope.altInputFormats = ['M!/d!/yyyy'];

                $scope.popup1 = {
                    opened: false
                };

                $scope.popup2 = {
                    opened: false
                };

                $scope.popup3 = {
                    opened: false
                };

                $scope.popup4 = {
                    opened: false
                };

                var tomorrow = new Date();
                tomorrow.setDate(tomorrow.getDate() + 1);
                var afterTomorrow = new Date();
                afterTomorrow.setDate(tomorrow.getDate() + 1);
                $scope.events = [
                    {
                        date: tomorrow,
                        status: 'full'
                    },
                    {
                        date: afterTomorrow,
                        status: 'partially'
                    }
                ];

                function getDayClass(data) {
                    var date = data.date,
                        mode = data.mode;
                    if (mode === 'day') {
                        var dayToCheck = new Date(date).setHours(0,0,0,0);

                        for (var i = 0; i < $scope.events.length; i++) {
                            var currentDay = new Date($scope.events[i].date).setHours(0,0,0,0);

                            if (dayToCheck === currentDay) {
                                return $scope.events[i].status;
                            }
                        }
                    }

                    return '';
                }

            }  ])

 


