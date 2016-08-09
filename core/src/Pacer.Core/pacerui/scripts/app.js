'use strict';

// declare modules
angular.module('Authentication', []);
angular.module('Home', []);
angular.module('PacerCore', []);
angular.module('MainQuery', []);
angular.module('Persons', []);
angular.module('Case', []);
angular.module('CaseSummary', []);
angular.module('Attorney', []);
angular.module('Party', []);
angular.module('Filers', []);
angular.module('DocketReport', []);
angular.module('DocketReportForm', []);
angular.module('CommonReportForm', []);
angular.module('CommonReport', []);



angular.module('Pacer', [
    'Authentication',
    'Home',
    'MainQuery',
    'Persons',
    'Case',
    'Attorney',
    'Party',
    'Filers',
    'DocketReportForm',
    'CommonReport',
    'CommonReportForm',
    'DocketReport',
    'CaseSummary',
    'PacerCore',
    'ngRoute',
    'ngCookies'
])

.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/', {
            controller: 'HomeController',
            templateUrl: 'modules/home/views/Home.html'
        })

        .when('/login', {
            controller: 'LoginController',
            templateUrl: 'modules/authentication/views/Login.html',
            hideMenus: true
        })

        .when('/search', {
            controller: 'MainQueryController',
            templateUrl: 'modules/mainQuery/views/MainQueryForm.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getQueryFormData();
                }
            }
        })

        .when('/getPersons', {
            controller: 'PersonsController',
            templateUrl: 'modules/persons/views/PersonsPage.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData();
                }
            }
        })

        .when('/getCaseNum', {
            controller: 'CaseController',
            templateUrl: 'modules/case/views/CaseHome.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseNum();
                }
            }
        })

        .when('/attorney', {
            controller: 'AttorneyController',
            templateUrl: 'modules/case/views/AttorneyHome.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.attorney();
                }
            }
        })

        .when('/party', {
            controller: 'PartyController',
            templateUrl: 'modules/case/views/PartyHome.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.party();
                }
            }
        })
        .when('/summary', {
            controller: 'CaseSummaryController',
            templateUrl: 'modules/case/views/CaseSummaryHome.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.summary();
                }
            }
        })

        .when('/filers', {
            controller: 'FilersController',
            templateUrl: 'modules/case/views/FilersHome.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.filers();
                }
            }
        })

        .when('/docket', {
            controller: 'DocketReportFormController',
            templateUrl: 'modules/case/views/DocketReportForm.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.docket();
                }
            }
        })

        .when('/docket/report', {
            controller: 'DocketReportController',
            templateUrl: 'modules/case/views/DocketReport.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.docketReport();
                }
            }
        })
        //Reports Data
        .when('/getCriminalCaseReport', {
            controller: 'CommonReportController',
            templateUrl: 'modules/case/views/CriminalCaseReport.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCriminalCaseReportData();
                }
            }
        })

        .when('/getCommonReport', {
            controller: 'CommonReportController',
            templateUrl: 'modules/case/views/CommonReport.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportData();
                }
            }
        })

        .when('/getCivilCaseReport', {
            controller: 'CommonReportController',
            templateUrl: 'modules/case/views/CivilCaseReportForm.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCivilCaseReportData();
                }
            }
        })
        .when('/getCalendarEventsReport', {
            controller: 'CommonReportController',
            templateUrl: 'modules/case/views/CalendarEventsReport.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCalendarEventsReportData();
                }
            }
        })
        .when('/getDocketActivityReport', {
            controller: 'CommonReportController',
            templateUrl: 'modules/case/views/DocketActivityReport.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getDocketActivityReportData();
                }
            }
        })
        .when('/getWrittenOptionsReport', {
            controller: 'CommonReportController',
            templateUrl: 'modules/case/views/WrittenOptionsReport.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getWrittenOptionsReportData();
                }
            }
        })
        //Reports form
        .when('/getCriminalCaseReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('CriminalCaseReport');
                }
            }
        })
        .when('/getCivilCaseReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('CivilCaseReport');
                }
            }
        })
        .when('/getCalendarEventsReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('CalendarEventsReport');
                }
            }
        })
        .when('/getDocketActivityReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('DocketActivityReport');
                }
            }
        })
        .when('/getWrittenOptionsReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('WrittenOptionsReport');
                }
            }
        })
        .when('/getJudgmentIndexReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('JudgmentIndexReportForm');
                }
            }
        })

        .otherwise({ redirectTo: '/login' });
}])
 
.run(['$rootScope', '$location', '$cookieStore', '$http',
    function ($rootScope, $location, $cookieStore, $http) {
        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }
 
        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in
            if ($location.path() !== '/login' && !$rootScope.globals.currentUser) {
                $location.path('/login');
            }
        });
    }]);