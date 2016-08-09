'use strict';

angular.module('billing', []);

angular.module('Case')
.controller('CaseController',
    ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
        function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {

            console.log("pacer data:"+pacerData);
            $scope.caseNum = pacerData;
            var ar = /\((.*)\)/.exec($scope.caseNum);
            $scope.shortCaseNum = ar[1];
            console.log ("short case num:"+$scope.shortCaseNum);

            $scope.attorney = function ()
            {
                $location.path("/attorney");
            }
        }]);


/*
angular.module('Attorney')
    .controller('AttorneyController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {

                $scope.attorneys = pacerData.attorneys;
                $scope.header = pacerData.header;
                $scope.billing = pacerData.billing;
                $scope.originalHtml = pacerData.originalHtml;
                $scope.parsed = pacerData.parsed;
                $rootScope.$broadcast('displayReceipt', pacerData.billing);
                console.log("Attorney Controller pacer data:"+pacerData);

            }]);
*/

angular.module('Party')
    .controller('PartyController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {

                $scope.party = pacerData.party;
                $scope.partyDetails = pacerData.partyDetails;
                $scope.billing = pacerData.billing;
                console.log("Attorney Controller pacer data:"+pacerData);

            }]);

angular.module('CaseSummary')
    .controller('CaseSummaryController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {

                $scope.casesummary = pacerData.casesummary;
                $scope.casesummaryDetails = pacerData.casesummaryDetails;
                $scope.billing = pacerData.billing;
                console.log("Case Summary Controller pacer data:"+pacerData);
            }]);

angular.module('Filers')
    .controller('FilersController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {

                $scope.filers = pacerData.filers;
                $scope.filersDetails = pacerData.filersDetails;
                $scope.billing = pacerData.billing;
                console.log("Filers Controller pacer data:"+pacerData);
            }]);

angular.module('CommonGetData')
    .controller('CommonGetDataController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {

                console.log("Controller:pacer data received");
                $scope.pacerData = pacerData;

                var sortFilerTable = function() {
                    var crim = document.getElementById('criminal-sort');
                    if (crim) new Tablesort(crim);
                    var civ = document.getElementById('civil-sort');
                    if (civ) new Tablesort(civ);
                    var rel = document.getElementById('related-sort');
                    if (rel) new Tablesort(rel);
                    var tran = document.getElementById('transaction-sort');
                    if (tran) new Tablesort(tran);
                    var dt = document.getElementById('dt-sort');
                    if (dt) new Tablesort(dt);
                    var nodt = document.getElementById('nodt-sort');
                    if (nodt) new Tablesort(nodt);
                }

                if (pacerData.billing) {
                    $scope.receipt = pacerData.billing;
                    $rootScope.$broadcast('displayReceipt', pacerData.billing);
                }

                $scope.$on('$viewContentLoaded', sortFilerTable);

                $scope.isArrayElem = function (elem){
                    let val =  Array.isArray(elem);
                    return val;
                }

                $scope.fetchCase = function (perlScript)
                {
                    perlScript  = perlScript.split('?').pop();
                    PacerCoreService.storeData('perlScript',perlScript);
                    $location.path("/case");
                }

            }]);

angular.module('PresentData')
    .controller('PresentDataController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {

                $scope.QueryData = pacerData;
                if (pacerData.billing) {
                    $scope.receipt = pacerData.billing;
                    $rootScope.$broadcast('displayReceipt', pacerData.billing);
                }
                
                console.log("PresentData Controller pacer data:"+pacerData);

            }])

angular.module('DocketReportForm')
    .controller('DocketReportFormController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {
                $scope.docketReportAction = pacerData;

                console.log("DocketReport Controller pacer data:"+pacerData);

                // set defaults
                $scope.q = {
                    "epa_case_num": PacerCoreService.getData('caseNumAN'),
                    "date_range_type": "Filed",
                    "list_of_parties_and_counsel": true,
                    "terminated_parties": true,
                    "output_format": "html",
                    "naturesuit_selected": "oldest date first"
                };

                $scope.run= function () {
                    PacerCoreService.storeData('DocketReportData',$scope.q);
                    $location.path("/docket/report");
                }

                $scope.clear = function() {
                    $scope.Query.filled_to = null;
                    $scope.Query.filled_from = null;
                    $scope.Query.lastentry_from = new Date();
                    $scope.Query.lastentry_to = new Date();
                };

                $scope.dateOptions = {
                    dateDisabled: disabled,
                    formatYear: 'yy',
                    maxDate: new Date(2020, 5, 22),
                    minDate: new Date(),
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

            }]);

angular.module('CaseFileLocationForm')
    .controller('CaseFileLocationFormController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {
                $scope.pacerData = pacerData;

                console.log("Case File Location Form Controller pacer data:"+pacerData);

                $scope.clear = function() {
                    $scope.q.view_CS1 = $scope.q.view_CS2 = $scope.q.view_CS3 = $scope.q.selectAll = false;
                };

                $scope.toggleSelectAll = function() {
                    $scope.q.view_CS1 = $scope.q.view_CS2 = $scope.q.view_CS3 = $scope.q.selectAll;
                }

                $scope.run = function() {
                    $location.path("/casefilelocationresults");
                }
            }]);

angular.module('ViewDocAttach')
    .controller('ViewDocAttachController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {
                $scope.pacerData = pacerData;

                console.log("ViewDocAttachController pacer data:"+pacerData);
                $scope.selectAll = false;

                $scope.clear = function() {
                    $scope.view_01 = $scope.view_02 = $scope.view_03 = $scope.view_04 = $scope.view_05 = $scope.view_06 = $scope.view_07 = false;
                };

                $scope.toggleSelectAll = function() {
                    $scope.view_01 = $scope.view_02 = $scope.view_03 = $scope.view_04 = $scope.view_05 = $scope.view_06 = $scope.view_07 = !$scope.selectAll;

                console.log("Clear and Select All");
                }

                $scope.run = function() {
                    $location.path("/documents3");
                }
            }]);


angular.module('CommonPostForm',['ngAnimate', 'ui.bootstrap','billing'])
    .controller('CommonPostFormController',
        ['$scope', '$rootScope', '$location', '$filter','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, $filter,PacerCoreService,pacerData) {

                console.log("CommonPostFormController pacer data:"+pacerData);


                //Get page form name
                let formName = Object.keys(pacerData).filter(function(item){ return item.match(/Form$/)})[0];
                formName = formName.replace(/Form$/,"");

                $scope.pacerData = pacerData;
                $scope.Query = {};
                console.log("CommonPostFormController pacer data:"+pacerData);

                $scope.submitForm = function(){
                    $scope.preparePostData();
                    if (formName == "MainForm"){
                        $scope.getPersons();
                    }else if (formName == "CaseFileLocation") {
                        $location.path("/casefilelocationresults");
                    } else if (formName == "DeadlinesHearings") {
                        $location.path("/deadlinesresults");
                    }
                    else if (formName == "DocketReport") {
                        $location.path("/getdocketreportresults");
                    }
                    else if (formName == "HistoryDocuments") {
                        $location.path("/gethistorydocumentsresults");
                    }
                    else if (formName == "RelatedTransactions") {
                        $location.path("/getrelatedtransactionsresults");
                    }
                    //reports
                    else if (formName == "CalendarEventsReport") {
                        $location.path("/getcalendareventsreport");
                    }
                    else if (formName == "CivilCaseReport") {
                        $location.path("/getcivilcasesreport");
                    }
                    else if (formName == "CriminalCaseReport") {
                        $location.path("/getcriminalcasesreport");
                    }
                    else if (formName == "DocketActivityReport") {
                        $location.path("/getdocketactivityreport");
                    }
                    else if (formName == "JudgmentIndexReport") {
                        $location.path("/getjudgmentindexreport");
                    }
                    else if (formName == "WrittenOptionsReport") {
                        $location.path("/getwrittenoptionsreport");
                    }
                    //report
                    else{
                            console.log ("ACTION NOT FOUND");
                        }
                }

                $scope.preparePostData= function () {
                    $scope.Query.CGIPerl = pacerData[formName+'Form'].action;
                    PacerCoreService.storeData('QueryData', $scope.Query);
                    $scope.allFormFields = {};
                    var allFields = pacerData[formName + 'Form'][formName + 'SelectFields'].concat(pacerData[formName + 'Form'][formName + 'NonSelectFields']);
                    for (var x in allFields) {
                        var nextf = allFields[x];
                        $scope.allFormFields[nextf.fieldName] = "";
                        if (nextf.type == "checkbox" || nextf.type == "radio"){
                            if (nextf.fieldValue && nextf.fieldValue != "true"){
                                $scope.allFormFields[nextf.fieldName] = nextf.fieldValue;
                            }else  if  (nextf.fieldValue && nextf.fieldValue == "true"){
                                $scope.allFormFields[nextf.fieldName] = "on";
                            }
                        }else if (nextf.type == "hidden"){
                            $scope.allFormFields[nextf.fieldName] = nextf.fieldValue;
                        }
                    }
                    $scope.isLongForm = false;
                    $scope.isCaseNumSearch = false;
                    for (var x in $scope.Query) {
                        var nextElem = $scope.Query[x];
                        console.log("nextElem:" + nextElem + ":" + (nextElem instanceof Date));

                        if (nextElem instanceof Date) {
                            $scope.Query[x] = $filter('date')(nextElem, 'MM/dd/yyyy');
                            $scope.isLongForm = true;
                        } else if (x == "case_num") {
                            $scope.isCaseNumSearch = true;
                        }
                        $scope.allFormFields[x] = $scope.Query[x];
                    }
                    PacerCoreService.storeData('CaseQueryData', $scope.allFormFields);
                }

                $scope.getPersons= function () {
                    if ($scope.isCaseNumSearch){
                        PacerCoreService.storeData('CaseQueryData', $scope.allFormFields);
                        $location.path("/directcase");
                    }else {
                        $scope.allFormFields['isLongForm'] = $scope.isLongForm;
                        PacerCoreService.storeData('CaseQueryData', $scope.allFormFields);
                        if ($scope.isLongForm)
                            $location.path("/getPersonsLong");
                        else
                            $location.path("/getPersonsShort");
                    }

                }


                $scope.getCommonReport= function () {
                   $scope.preparePostData();
                   $location.path("/getCommonReport");
                }

                $scope.openFns=[function(){$scope.open1()},function(){$scope.open1()},function(){$scope.open2()},function(){$scope.open3()}];
                $scope.isOpenFns=[$scope.popup1,$scope.popup1,$scope.popup2,$scope.popup3];

                $scope.clear = function() {
                    $scope.Query.filled_to = null;
                    $scope.Query.filled_from = null;
                    $scope.Query.EndDate = null;
                    $scope.Query.StartDate = null;
                    $scope.Query.lastentry_from = new Date();
                    $scope.Query.lastentry_to = new Date();
                };

                $scope.dateOptions = {
                    dateDisabled: disabled,
                    formatYear: 'yy',
                    maxDate: new Date(2020, 5, 22),
                    startingDay: 1,
                    showWeeks: false
                };

                // Disable weekend selection
                function disabled(data) {
                    var date = data.date,
                        mode = data.mode;
                    return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
                }

                $scope.open1 = function() {
                    $scope.popup1.opened = true;
                    $scope.isOpenFns[1] = true;
                };

                $scope.open2 = function() {
                    $scope.popup2.opened = true;
                    $scope.isOpenFns[2] = true;
                };

                $scope.open3 = function() {
                    $scope.popup3.opened = true;
                    $scope.isOpenFns[3] = true;
                };

                $scope.open4 = function() {
                    $scope.popup4.opened = true;
                    $scope.isOpenFns[4] = true;
                };


                $scope.setDate = function(year, month, day) {
                    $scope.dt = new Date(year, month, day);
                };


                $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd/MM/yyyy', 'MM/dd/yyyy','shortDate'];
                $scope.format = $scope.formats[3];
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


            }]);



angular.module('CommonReport')
    .controller('CommonReportController',
        ['$scope', '$rootScope', '$location', 'AuthenticationService','PacerCoreService','pacerData',
            function ($scope, $rootScope, $location, AuthenticationService,PacerCoreService,pacerData) {

                $scope.commonReportData = pacerData;
                
                if (pacerData.billing) {
                    $scope.receipt = pacerData.billing;
                    $rootScope.$broadcast('displayReceipt', pacerData.billing);
                }
                
                console.log("CommonReportController pacer data:"+pacerData);

                $scope.fetchCase = function (perlScript)
                {
                    PacerCoreService.storeData('perlScript',perlScript);
                    $location.path("/case");
                }

            }]);


angular.module('message', ['auth'])
    .controller('message', 
        function($scope, $http, $sce, auth) {

            $scope.authenticated = function() {
                return auth.authenticated;
            }

            $scope.getPdf = function()
            {
                  $http.get('/api/some-pdfr', {responseType: 'arraybuffer'})
                  .success(function (data) {
                    var file = new Blob([data], {type: 'application/pdf'});
                    var fileURL = URL.createObjectURL(file);
                    window.open(fileURL);
                  });
            }
        });

