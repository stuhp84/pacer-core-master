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
angular.module('CaseFileLocationForm', []);
angular.module('DocketReport', []);
angular.module('DocketReportForm', []);
angular.module('CommonReportForm', []);
angular.module('CommonReport', []);
angular.module('CommonMainData', []);
angular.module('LandingPage', []);
angular.module('PresentData', []);
angular.module('Shared', []);
angular.module('ViewDocAttach', []);

angular.module('Pacer', [
    'Authentication',
    'Home',
    'MainQuery',
    'Persons',
    'Case',
    'Attorney',
    'Party',
    'Filers',
    'CaseFileLocationForm',
    'DocketReportForm',
    'CommonReport',
    'CommonReportForm',
    'DocketReport',
    'CaseSummary',
    'CommonMainData',
    'PresentData',
    'PacerCore',
    'LandingPage',
    'ViewDocAttach',
    'Shared',
    'ngRoute',
    'ngCookies'
])

.config(['$routeProvider', function ($routeProvider,$routeParams) {

    $routeProvider
        .when('/home', {
            controller: 'HomeController',
            templateUrl: 'modules/home/views/Home.html',
            title: 'Home'
        })

        .when('/login', {
            controller: 'LoginController',
            templateUrl: 'modules/authentication/views/Login.html',
            title: 'Search'
        })

        .when('/search', {
            controller: 'MainQueryController',
            templateUrl: 'modules/mainQuery/views/MainQueryForm.html',
            title: 'Search',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('MainForm',"getmainformstructure",1);
                }
            }
        })

        .when('/tocase', {
            controller: 'LandingPageController',
            templateUrl: 'modules/case/views/CaseLanding.html',
            title: 'Case',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseLandingPageData2 ();
                }
            }
        })

        .when('/case', {
            controller: 'LandingPageController',
            templateUrl: 'modules/case/landingPage/views/LandingPage.html',
            title: 'Case',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseLandingPageData (1);
                }
            }
        })

        .when('/directcase', {
            controller: 'LandingPageController',
            templateUrl: 'modules/case/landingPage/views/LandingPage.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsDataNoCases("searchcasesshort",1);
                }
            }
        })

        .when('/searchbyname/:courtId/:caseInput', {
            controller: 'PersonsController',
            templateUrl: 'modules/persons/views/PersonsPageShort.html',
            title: 'Case',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.searchByBusinessName ();
                }
            }
        })

        .when('/searchbycasenumber/:courtId/:caseInput', {
            controller: 'LandingPageController',
            templateUrl: 'modules/case/landingPage/views/LandingPage.html',
            title: 'Case',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                       return PacerCoreService.searchByCaseNumber();
                }
            }
        })

        .when('/getPersonsLong', {
            controller: 'PersonsController',
            templateUrl: 'modules/persons/views/PersonsPageLong.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("searchcaseslong",1);
                }
            }
        })
        .when('/getPersonsShort', {
            controller: 'PersonsController',
            templateUrl: 'modules/persons/views/PersonsPageShort.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("searchcasesshort",1);
                }
            }
        })
        /*
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
        */
        .when('/getCaseNum', {
            controller: 'CommonReportController',
            templateUrl: 'modules/case/views/CaseSummary.html',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseNum (1);
                }
            }
        })

        .when('/attorneynew', {
            controller: 'AttorneyController',
            templateUrl: 'modules/case/attorneys/views/Attorneys.html',
            title: 'Attorneys2',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getMockData("case/64541/attorney");
                }
            }
        })

        .when('/attorney', {
            controller: 'AttorneyController',
            templateUrl: 'modules/case/views/AttorneyList.html',
            title: 'Attorneys',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.attorney();
                }
            }
        })

        .when('/alias', {
            controller: 'CommonMainDataController',
            templateUrl: 'modules/case/views/Aliases.html',
            title: 'Aliases',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonMainData("Alias");
                }
            }
        })

        .when('/associated', {
            controller: 'CommonMainDataController',
            templateUrl: 'modules/case/views/AssociatedCases.html',
            title: 'Associated Cases',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonMainData("AssociatedCases");
                }
            }
        })

        .when('/status', {
            controller: 'CommonMainDataController',
            templateUrl: 'modules/case/views/Status.html',
            title: 'Case Status',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonMainData("Status");
                }
            }
        })

        .when('/party', {
            controller: 'CommonMainDataController',
            templateUrl: 'modules/case/views/PartyList.html',
            title: 'Parties',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonMainData("Party");
                }
            }
        })
        .when('/summary', {
            controller: 'PresentDataController',
            templateUrl: 'modules/case/views/CaseSummary.html',
            title: 'Case Summary',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.summary("CaseSummary");
                }
            }
        })

        .when('/filers', {
            controller: 'CommonMainDataController',
            templateUrl: 'modules/case/views/FilersHome.html',
            title: 'Filers',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonMainData("Filers");
                }
            }
        })

        //Erol
        .when('/casefilelocation', {
            controller: 'CaseFileLocationFormController',
            templateUrl: 'modules/case/views/CaseFileLocationForm.html',
            title: 'Case File Locations',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('CaseFileLocation');
                }
            }
        })

        .when('/casefilelocationresults', {
            controller: 'CommonReportController',
            templateUrl: 'modules/case/views/CaseFileLocation.html',
            title: 'Case File Locations',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return [];
                }
            }
        })

        .when('/deadlinesandhearings', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/DeadlinesForm.html',
            title: 'Deadlines / Hearings',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('DeadlinesHearings');
                }
            }
        })

        .when('/deadlinesandhearings2', {
            controller: 'CommonMainDataController',
            templateUrl: 'modules/case/views/DeadlinesHearings.html',
            title: 'Deadlines / Hearings',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('DeadlinesHearings');
                }
            }
        })        

        .when('/historyanddocuments', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/HistoryDocsForm.html',
            title: 'History / Documents',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('HistoryDocuments');
                }
            }
        })

        .when('/history2', {
            controller: 'CommonMainDataController',
            templateUrl: 'modules/case/views/HistoryDocs.html',
            title: 'History / Documents',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('HistoryDocuments');
                }
            }
        })

        .when('/related', {
            controller: 'MainQueryController',
            templateUrl: 'modules/case/views/RelatedTransactionsForm.html',
            title: 'Related Transactions',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('RelatedTransactions');
                }
            }})

        .when('/related2', {
            controller: 'CommonMainDataController',
            templateUrl: 'modules/case/views/RelatedTransactions.html',
            title: 'Related Transactions',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('RelatedTransactions');
                }
            }})

        .when('/documents', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/ViewDocForm.html',
            title: 'View a Document',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('ViewDocument');
            }}})

        .when('/documents2', {
            controller: 'ViewDocAttachController',
            templateUrl: 'modules/case/views/ViewDocAttach.html',
            title: 'View a Document',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('ViewDocument');
            }}})

        .when('/documents3', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/ViewDocCharges.html',
            title: 'View a Document',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('ViewDocument');
            }}})

        .when('/documents4', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/PDF.html',
            title: 'View a Document',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('ViewDocument');
            }}})        

        .when('/docket', {
            controller: 'DocketReportFormController',
            templateUrl: 'modules/case/views/DocketReportForm.html',
            title: 'Docket Report',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.docket();
                }
            }
        })

        .when('/docket/report', {
            controller: 'DocketReportController',
            templateUrl: 'modules/case/views/DocketReport.html',
            title: 'Docket Report',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.docketReport();
                }
            }
        })
        .when('/docket/reportnew', {
            controller: 'DocketReportController',
            templateUrl: 'modules/report/docketSheet/views/DocketReport.html',
            hideMenus: true,
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getMockData("getdocketreport/477760223449826-L_452_0-1");
                }
            }
        })
        //Reports Data
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
        //Reports form
        .when('/getCriminalCaseReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            title: 'Criminal Cases',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('CriminalCaseReport');
                }
            }
        })
        .when('/getCivilCaseReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            title: 'Civil Cases',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('CivilCaseReport');
                }
            }
        })
        .when('/getCalendarEventsReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            title: 'Calendar Events',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('CalendarEventsReport');
                }
            }
        })
        .when('/getDocketActivityReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            title: 'Docket Activity',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('DocketActivityReport');
                }
            }
        })
        .when('/getWrittenOptionsReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            title: 'Written Opinions',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('WrittenOptionsReport');
                }
            }
        })
        .when('/getJudgmentIndexReportForm', {
            controller: 'CommonReportFormController',
            templateUrl: 'modules/case/views/CommonReportForm.html',
            title: 'Judgement Index',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonReportFormData('JudgmentIndexReportForm');
                }
            }
        })

        .otherwise({ redirectTo: '/home' });
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
        
        $rootScope.$on('$routeChangeStart', function(event, next, current) {
            // next is an object that is the route that we are starting to go to
            // current is an object that is the route where we are currently
            
            var currentPath, nextPath;
            if (current && 'originalPath' in current) currentPath = current.originalPath;
            if (next && 'originalPath' in next) nextPath = next.originalPath;

            console.log('Starting to leave %s to go to %s', currentPath, nextPath);
        });
        
        $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
            $rootScope.title = (current && current.$$route && 'title' in current.$$route)? current.$$route.title : null;
            $rootScope.sidebar = (current && current.$$route && 'sidebar' in current.$$route)? current.$$route.sidebar : null;
        });
    }]);