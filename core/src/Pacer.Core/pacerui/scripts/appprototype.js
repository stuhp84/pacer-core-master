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
angular.module('CommonPostForm', []);
angular.module('CommonReport', []);
angular.module('CommonGetData', []);
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
    'CommonPostForm',
    'DocketReport',
    'CaseSummary',
    'CommonGetData',
    'PresentData',
    'PacerCore',
    'LandingPage',
    'Shared',
    'ngRoute',
    'ngCookies',
    'ViewDocAttach'
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
            controller: 'CommonPostFormController',
            templateUrl: 'modules/case/mainQuery/views/MainQueryForm.html',
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
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/mainQuery/views/PersonsPageShort.html',
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
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/mainQuery/views/PersonsPageLong.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("searchcaseslong",1);
                }
            }
        })
        .when('/getPersonsShort', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/mainQuery/views/PersonsPageShort.html',
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

        .when('/attorney', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/attorneys/views/Attorneys.html',
            title: 'Attorneys',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseData(1,"attorney");
                }
            }
        })

        .when('/alias', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/alias/views/Aliases.html',
            title: 'Aliases',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseData(1,"alias");
                }
            }
        })

        .when('/associated', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/associatedCases/views/AssociatedCases.html',
            title: 'Associated Cases',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseData(1,"associatedcases");
                }
            }
        })

        .when('/status', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/status/views/Status.html',
            title: 'Case Status',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseData(1,"status");
                }
            }
        })

        .when('/party', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/parties/views/PartyList.html',
            title: 'Parties',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseData(1,"parties");
                }
            }
        })
        .when('/summary', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/caseSummary/views/CaseSummary.html',
            title: 'Case Summary',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseData(1,"casesummary");
                }
            }
        })

        .when('/filers', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/filers/views/FilersHome.html',
            title: 'Filers',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCaseData(1,"filers");
                }
            }
        })


        .when('/search', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/case/mainQuery/views/MainQueryForm.html',
            title: 'Search',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('MainForm',"getmainformstructure",1);
                }
            }
        })



        //Erol
        .when('/casefilelocation', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/case/caseFileLocation/views/CaseFileLocationForm.html',
            title: 'Case File Locations',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('MainForm',"getcasefilelocationstructure",1);
                }
            }
        })

        .when('/casefilelocationresults', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/caseFileLocation/views/CaseFileLocation.html',
            title: 'Case File Locations',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("casefilelocationresults",1);
                }
            }
        })

        .when('/deadlinesandhearings', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/case/deadlines/views/DeadlinesForm.html',
            title: 'Deadlines / Hearings',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('MainForm',"getcasedeadlinestructure",1);
                }
            }
        })

        .when('/deadlinesresults', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/deadlines/views/Deadlines.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("deadlinesresults",1);
                }
            }
        })

        .when('/getdocketreportresults', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/report/docketSheet/views/DocketReport.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("getdocketreportresults",1);
                }
            }
        })
        .when('/gethistorydocumentsresults', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/historyDocuments/views/HistoryDocuments.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("gethistorydocumentsresults",1);
                }
            }
        })
        //reports
        .when('/getcalendareventsreport', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/report/calendarEvents/views/CalendarEvents.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("getcalendareventsreport",1);
                }
            }
        })
        .when('/getwrittenoptionsreport', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/report/writtenOptions/views/WrittenOptionsReport.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("getwrittenoptionsreport",1);
                }
            }
        })
        .when('/getcriminalcasesreport', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/report/criminalCases/views/CriminalCaseReport.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("getcriminalcasesreport",1);
                }
            }
        })
        .when('/getcivilcasesreport', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/report/civilCases/views/CivilCaseReport.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("getcivilcasesreport",1);
                }
            }
        })
        .when('/getjudgmentindexreport', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/report/judgmentIndex/views/JudgmentIndexReport.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("getjudgmentindexreport",1);
                }
            }
        })
        .when('/getdocketactivityreport', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/report/docketActivity/views/DocketActivityReport.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("getdocketactivityreport",1);
                }
            }
        })
        //reports
        .when('/getrelatedtransactionsresults', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/relatedTransactions/views/RelatedTransactions.html',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getPersonsData("getrelatedtransactionsresults",1);
                }
            }
        })

        .when('/historyanddocuments', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/case/historyDocuments/views/HistoryDocumentsForm.html',
            title: 'History / Documents',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('MainForm',"getcasehistorytructure",1);
                }
            }
        })

        .when('/relatedtransactions', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/case/relatedTransactions/views/RelatedTransactionsForm.html',
            title: 'Related Transactions',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('MainForm',"getcaserelatedtransactionstructure",1);
                }
            }})

        .when('/documents', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/case/viewDocument/views/ViewDocumentForm.html',
            title: 'View a Document',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('MainForm',"getcaseviewdocumentstructure",1);
                }}})

        .when('/history2', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/views/HistoryDocs.html',
            title: 'History / Documents',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('HistoryDocuments');
                }
            }
        })

        .when('/history3', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/views/RelatedTransactionsCharges.html',
            title: 'Related Transactions',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('RelatedTransactions');
                }
            }})

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
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/views/RelatedTransactions.html',
            title: 'Related Transactions',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('RelatedTransactions');
                }
            }})

        .when('/related3', {
            controller: 'CommonGetDataController',
            templateUrl: 'modules/case/views/RelatedTransactionsCharges.html',
            title: 'Related Transactions',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('RelatedTransactions');
                }
            }})

        .when('/documents2', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/case/views/ViewDocCharges.html',
            title: 'View a Document',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('ViewDocument');
            }}})

        .when('/documents3', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/case/views/PDF.html',
            title: 'View a Document',
            sidebar: 'Case',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('ViewDocument');
            }}})

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
            controller: 'CommonPostFormController',
            templateUrl: 'modules/report/criminalCases/views/CriminalCaseReportForm.html',
            title: 'Criminal Cases',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('CriminalCaseReportForm',"getcriminalcasereportstructure",1);
                }
            }
        })
        .when('/getCivilCaseReportForm', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/report/civilCases/views/CivilCaseReportForm.html',
            title: 'Civil Cases',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('CivilCaseReportForm',"getcivilcasereportstructure",1);
                }
            }
        })
        .when('/getCalendarEventsReportForm', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/report/calendarEvents/views/CalendarEventsReportForm.html',
            title: 'Calendar Events',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('CalendarEventsReportForm',"getcalendareventsreportstructure",1);
                }
            }
        })
        .when('/getDocketActivityReportForm', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/report/docketActivity/views/DocketActivityReportForm.html',
            title: 'Docket Activity',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('DocketActivityReportForm',"getdocketactivityreportstructure",1);
                }
            }
        })
        .when('/getWrittenOptionsReportForm', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/report/writtenOptions/views/WrittenOptionsReportForm.html',
            title: 'Written Opinions',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('WrittenOptionsReportForm',"getwrittenoptionsreportstructure",1);
                }
            }
        })
        .when('/getJudgmentIndexReportForm', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/report/judgmentIndex/views/JudgmentIndexReportForm.html',
            title: 'Judgement Index',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('JudgmentIndexReportForm',"getjudgmentindexreportstructure",1);
                }
            }
        })

        .when('/docket', {
            controller: 'CommonPostFormController',
            templateUrl: 'modules/report/docketSheet/views/DocketReportForm.html',
            title: 'Docket Report',
            sidebar: 'Report',
            resolve: {
                pacerData: function(PacerCoreService) {
                    return PacerCoreService.getCommonFormData('DocketReportForm',"getdocketreportstructure",1);
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