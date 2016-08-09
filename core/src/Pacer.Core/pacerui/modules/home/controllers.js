'use strict';
 
angular.module('Home',['ui.router', 'ui.bootstrap','ngTouch', 'angucomplete-alt'])

.controller('HomeController',
    ['$scope', '$rootScope', '$location', '$routeParams','AuthenticationService','PacerCoreService',
    function ($scope, $rootScope, $location, $routeParams,AuthenticationService,PacerCoreService) {
        console.log ("Home menu");

        $scope.lookupCase = function () {

            var caseInput = $scope.caseInput;
            if ($scope.selectedCase && $scope.selectedCase.description){
                caseInput = $scope.selectedCase.description;
                console.log ("selected Case with "+caseInput);
            }
            $routeParams.caseInput = caseInput;
            $routeParams.courtId = 1;
            console.log ("lookupCase called:"+caseInput);

            PacerCoreService.storeData("courtId",1);
            PacerCoreService.storeData("caseInput",caseInput);

            console.log ("User typed search:"+caseInput);
            var isItCaseNum = caseInput.match(/[0-9\-\:]/);
            if (isItCaseNum){
                $location.path("/searchbycasenumber/"+1+"/"+caseInput);
            }else{
                console.log ("Searching by name..");
                $location.path("/searchbyname/"+1+"/"+caseInput);
            }
            
        };

        $scope.inputChanged = function(str) {
            console.log ("User typed "+str);
            $scope.caseInput = str;
        }

        $scope.caseLookupAPI = function(caseNumber, timeoutPromise) {
            console.log ("caseLookupAPI called:"+caseNumber+":"+timeoutPromise);

            if (caseNumber.match(/[0-9\-\:]/)) {
                return PacerCoreService.lookupCaseNumber(1, caseNumber, timeoutPromise);
            }
            var promise = new Promise(function(resolve, reject) {
                resolve({data:{
                    cases: [
                        {
                            caseTitle: caseNumber,
                            caseId: caseNumber
                        }]}});
            });
            return promise;
        }

        $scope.dropboxitemselected = function (item) {
            console.log ("dropboxitemselected:"+item);

            $scope.selectedItem = item;

            return false;
        }

        $scope.display = function (receipt){
            $scope.receipt = receipt;
        };

       $rootScope.$on('displayReceipt', function ($evt, data) {
            console.log ("displaying receipt");
            $scope.display(data);
        });
        
        $scope.lookupCaseNumber2 = function () {
            PacerCoreService.lookupCaseNumber($scope.caseNumber)
                .then(function(result) {
                    $scope.cases = result;
                },
                function(a, b, c) {
                    $scope.cases = null;
                })
        }

        $scope.lookupCaseNumber = function () {
            PacerCoreService.storeData('caseNumAN',$scope.caseNumber);
                $location.path("/tocase");
        }

        $scope.getTemplate = function (){
            var state = $rootScope.sidebar;
            if (state == "Case")
                return "case-sidebar.html";
            else if (state == "Report")
                return "report-sidebar.html";
            else
                return "blank.html";
        };

        $scope.$on('$viewContentLoaded', function ($evt, data) {
            console.log ("page loaded");
            $scope.receipt = null;
            //$scope.caseNumber = null;
            //$scope.cases = null;
            $scope.naturesuit = PacerCoreService.naturesuit;
            $scope.causeaction = PacerCoreService.causeaction;
        });

        $scope.$on('$routeChangeSuccess', function ($evt, data) {
            console.log ("route changing");
            $scope.receipt = null;
        });

        $scope.logout = function () {
            AuthenticationService.ClearCredentials();
            $location.path("/login");
            console.log ("logout completed");
        };

        $scope.home = function ()
        {
            $location.path("/home");
        }

        $scope.search = function ()
        {
            $location.path("/search");
        }

        $scope.attorney = function ()
        {
            $location.path("/attorney");
        }

        $scope.party = function ()
        {
            $location.path("/party");
        }

        $scope.summary = function ()
        {
            $location.path("/summary");
        }

        $scope.filers = function ()
        {
            $location.path("/filers");
        }

        $scope.associated = function ()
        {
            $location.path("/associated");
        }
        $scope.status = function ()
        {
            $location.path("/status");
        }
        $scope.alias = function ()
        {
            $location.path("/alias");
        }

        $scope.casefilelocation = function ()
        {
            $location.path("/casefilelocation");
        }
        $scope.deadlinesandhearings = function ()
        {
            $location.path("/deadlinesandhearings");
        }
        $scope.docket = function ()
        {
            $location.path("/docket");
        }
        $scope.historyanddocuments = function ()
        {
            $location.path("/historyanddocuments");
        }
        $scope.related = function ()
        {
            $location.path("/related");
        }
        $scope.documents = function ()
        {
            $location.path("/documents");
        }

        $scope.docket=function ()
        {
            console.log ("docket called");
            $location.path("/docket");
        }

        $scope.getCriminalCaseReportForm=function ()
        {
            console.log ("getCriminalCaseReportForm called");
            $location.path("/getCriminalCaseReportForm");
        }
        $scope.getCivilCaseReportForm=function ()
        {
            console.log ("getCivilCaseReportForm called");
            $location.path("/getCivilCaseReportForm");
        }
        $scope.getDocketActivityReportForm=function ()
        {
            console.log ("getDocketActivityReportForm called");
            $location.path("/getDocketActivityReportForm");
        }
        $scope.getCalendarEventsReportForm=function ()
        {
            console.log ("getCalendarEventsReportForm called");
            $location.path("/getCalendarEventsReportForm");
        }
        $scope.getWrittenOptionsReportForm=function ()
        {
            console.log ("getWrittenOptionsReportForm called");
            $location.path("/getWrittenOptionsReportForm");
        }
        $scope.getJudgmentIndexReportForm=function ()
        {
            console.log ("getJudgmentIndexReportForm called");
            $location.path("/getJudgmentIndexReportForm");
        }


        $scope.remoteUrlRequestFn = function(str) {
            return {q: str};
        };
        /***
         * Send a broadcast to the directive in order to clear itself
         * if an id parameter is given only this ancucomplete is cleared
         * @param id
         */
        $scope.clearInput = function (id) {
            if (id) {
                $scope.$broadcast('angucomplete-alt:clearInput', id);
            }
            else{
                $scope.$broadcast('angucomplete-alt:clearInput');
            }
        }

        /***
         * Send a broadcast to the directive in order to change itself
         * if an id parameter is given only this ancucomplete is changed
         * @param id
         */
        $scope.changeInput = function (id) {
            if (id) {
                var pos = Math.floor(Math.random() * ($scope.countries.length - 1));
                $scope.$broadcast('angucomplete-alt:changeInput', id, $scope.countries[pos]);
            }
        }

        $scope.disableInput = true;

    }]);