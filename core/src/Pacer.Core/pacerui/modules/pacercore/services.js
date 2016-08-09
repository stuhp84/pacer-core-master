'use strict';

angular.module('PacerCore')

    .factory('PacerCoreService',
        ['Base64', '$http', '$cookieStore', '$rootScope', '$timeout',
            function (Base64, $http, $cookieStore, $rootScope, $timeout) {
                var service = {};
                var host = 'http://localhost:5000/courts/';

                var reportQueryActions ={
                    'CriminalCaseReport':'',
                    'CivilCaseReport':'',
                    'CalendarEventsReport':'',
                    'DocketActivityReport':'',
                    'WrittenOptionsReport':'',
                }

                service.cache = {};

                service.storeData = function (dataID,data){
                    service.cache[dataID] = data;
                }

                service.getData = function (dataID){
                    return service.cache[dataID];
                }

                service.getQueryFormData = function () {
                    var requestObject = {
                        method: 'POST',
                        url: host+'/search',
                        headers: {
                            'Content-Type': 'application/json;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("new function is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            return {
                                cause_action: optionsData.cause_action,
                                nature_suit: optionsData.nature_suit
                            };
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };


                service.getPersonsDataNoCases = function (action,courtId) {
                    var perlScript = service.cache['perlScript'];
                    var dataToBSent = service.cache['CaseQueryData'];
                    var requestObject = {
                        method: 'POST',
                        url: host+courtId+"/"+action,
                        headers: {
                            'Content-Type': 'application/json;charset=utf-8'
                        },
                        data: dataToBSent
                    };

                    var promise = $http(requestObject).then(
                        function(response){
                            var landingData = response.data;
                            var caseNum = landingData.header.CaseNum;
                            var ar2 = /=(.*)\(/.exec(caseNum);
                            service.cache['caseID'] = ar2[1];
                            service.cache['caseNum'] = caseNum;
                            var ar = /\((.*)\)/.exec(caseNum);
                            service.cache['shortCaseNum'] = ar[1];
                            landingData["caseID"] = service.cache['caseID'];
                            return landingData;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.getPersonsData = function (action,courtId) {
                    var perlScript = service.cache['perlScript'];
                    var dataToBSent = service.cache['CaseQueryData'];
                    var requestObject = {
                        method: 'POST',
                        url: host+courtId+"/"+action,
                        headers: {
                            'Content-Type': 'application/json;charset=utf-8'
                        },
                        data: dataToBSent
                    };

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            return optionsData;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.chooseCase = function () {
                    var perlScript = service.cache['perlScript'];
                    var requestObject = {
                        method: 'GET',
                        url: host+'/getCaseNum?'+perlScript,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("getCaseNum is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var caseNum = response.data.caseNum;
                            service.cache['caseNum'] = caseNum;
                            var ar = /\((.*)\)/.exec(caseNum);
                            service.cache['shortCaseNum'] = ar[1];
                            return caseNum;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };
                
                service.lookupCaseNumber = function (courtId,caseNumber, timeoutPromise) {

                    var urlExecuted = host+courtId+"/caselookup/"+caseNumber;

                    var requestObject = {
                        method: 'GET',
                        url: urlExecuted,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { },
                        timeout:timeoutPromise
                    };
                    
                    console.log('Lookup up case number:' + caseNumber);
                    
                    var promise = $http(requestObject).then(
                        function(response){
                            var landingData = response.data;
                            service.storeData("CasePairs",landingData.cases);
                            return response;
                        },
                        function(queryFormData){
                            console.log ("Couldn't lookup case number.");
                            return[];
                        });

                    return promise;
                }


                service.searchByCaseNumber = function (courtId, caseNum) {

                    courtId = service.getData("courtId");
                    caseNum = service.getData("caseInput");

                    var urlExecuted = host+courtId+"/searchbycasenum/"+caseNum;
                    console.log ("searchByCaseNumber:"+urlExecuted);

                    var requestObject = {
                        method: 'GET',
                        url: urlExecuted,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };

                    console.log('Lookup up case number:' + caseNum);

                    var promise = $http(requestObject).then(
                        function(response){
                            var caseHeader = response.data;

                            service.cache['caseID'] = caseHeader.header1.CaseNum;
                            service.cache['caseNum'] = caseHeader.header1.CaseNumShort;
                            service.cache['shortCaseNum'] = caseHeader.header1.CaseNumShort;

                            return caseHeader;
                        },
                        function(queryFormData){
                            console.log ("Couldn't lookup case number.");
                            return[];
                        });

                    return promise;
                }

                service.searchByBusinessName = function (courtId, name) {

                    courtId = service.getData("courtId");
                    name = service.getData("caseInput");

                    var urlExecuted = host+courtId+"/searchbyname/"+name;
                    console.log ("searchByBusinessName:"+urlExecuted);

                    var requestObject = {
                        method: 'GET',
                        url: urlExecuted,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };

                    console.log('Lookup up last/business name:' + name);

                    var promise = $http(requestObject).then(
                        function(response){
                            var caseResults = response.data;
                            return caseResults;
                        },
                        function(queryFormData){
                            console.log ("Couldn't lookup case number.");
                            return[];
                        });

                    return promise;
                }

                service.getCaseLandingPageData = function (courtId) {
                    var perlScript = service.cache['perlScript'];
                    var urlExecuted = host+courtId+"/getcaselandingpage/"+perlScript;
                    var requestObject = {
                        method: 'GET',
                        url: urlExecuted,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("getCaseNum is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var landingData = response.data;
                            var caseNum = landingData.CaseNum;
                            var ar2 = /=(.*)\(/.exec(caseNum);
                            service.cache['caseID'] = ar2[1];
                            service.cache['caseNum'] = caseNum;
                             var ar = /\((.*)\)/.exec(caseNum);
                            service.cache['shortCaseNum'] = ar[1];
                            landingData["caseID"] = service.cache['caseID'];
                            return landingData;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.getCaseLandingPageData2 = function () {

                    var caseNumAN = service.cache['caseNumAN'];

                    var requestObject = {
                        method: 'GET',
                        url: host+'/performOnlyCaseSearch?caseNum='+caseNumAN,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("getCaseLandingPageData2 is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var landingData = response.data;
                            var caseNum = landingData.caseNum;
                            service.cache['caseNum'] = caseNum;
                            var ar = /\((.*)\)/.exec(caseNum);
                            if (ar != null)
                                service.cache['shortCaseNum'] = ar[1];
                            return landingData;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return null;
                        });

                    return promise;
                };


                service.getCaseNum = function (courtId) {
                    var perlScript = service.cache['perlScript'];
                    var urlExecuted = host+courtId+"/getcasenum/"+perlScript;
                    var requestObject = {
                        method: 'GET',
                        url: urlExecuted,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("getCaseNum is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var caseNum = response.data.caseNum;
                            service.cache['caseNum'] = caseNum;
                            var ar = /\((.*)\)/.exec(caseNum);
                            service.cache['shortCaseNum'] = ar[1];
                            //return service.getCommonMainData("CaseSummary");
                            return service.summary(courtId);
                            //return caseNum;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.attorney = function () {
                    var requestObject = {
                        method: 'GET',
                        url: host+'/getAttorney?caseID='+service.cache['shortCaseNum'],
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("attorney is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                          
                            service.cache['attorney'] = optionsData;

                            return service.cache['attorney'];
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.party = function () {
                    var requestObject = {
                        method: 'GET',
                        url: host+'/getParty?caseID='+service.cache['shortCaseNum'],
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("party is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache['party'] = {
                                party: optionsData.party,
                                partyDetails: optionsData.partyDetails,
                                billing:optionsData.billing
                            };
                            return service.cache['party'];
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.getCaseData = function (courtId,actionName) {
                    var urlExecuted = `${host}${courtId}/case/${service.cache['shortCaseNum']}/${actionName}`;
                    var requestObject = {
                        method: 'GET',
                        url: urlExecuted,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("summary is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache['caseData'] = optionsData;
                            return optionsData;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.summary = function (courtId) {
                    var urlExecuted = host+courtId+"/case/"+service.cache['shortCaseNum']+"/casesummary";
                    var requestObject = {
                        method: 'GET',
                        url: urlExecuted,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("summary is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache['commonReportData'] = optionsData;
                            return optionsData;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.filers = function () {
                    var requestObject = {
                        method: 'GET',
                        url: host+'/getFilers?caseID='+service.cache['shortCaseNum'],
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("Filers is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache['filers'] = {
                                filers: optionsData.filers,
                                filersDetails: optionsData.filersDetails,
                                billing:optionsData.billing
                            };
                            return service.cache['filers'];
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.docket = function () {
                    var action = "DktRpt.pl";
                    var requestObject = {
                        method: 'GET',
                        url: host+"/getFormAction?actionPath="+action+'&caseID='+service.cache['shortCaseNum'],
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        }
                    };
                    console.log ("docket is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache['docketReportAction'] = optionsData.formAction;
                            return service.cache['docketReportAction'];
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.docketReport = function () {
                    var cNum = service.cache['shortCaseNum'];
                    var cacheData = service.cache['DocketReportData'];
                    var data = {};
                    for (var x in cacheData){
                        data[x] = cacheData[x];
                    }
                    data['all_case_ids'] = cNum;
                    data['CaseNum_'+cNum] = 'on';

                    var requestObject = {
                        method: 'POST',
                        url: host+'/getDocketReport?actionPath='+service.cache['docketReportAction'],
                        headers: {
                            'Content-Type': 'application/json;charset=utf-8'
                        },
                        data: data
                    };

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache['docketReportData'] = optionsData;
                            return optionsData;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.getMockData = function (path) {
                    var requestObject = {
                        method: 'GET',
                        url: host+'/1/'+path,
                        headers: {
                            'Content-Type': 'application/json;charset=utf-8'
                        },
                    };

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache['docketReportData'] = optionsData;
                            return optionsData;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.getCommonPostResultData = function (){

                    var cacheData = service.cache['ReportData'];
                    var data = {};
                    for (var x in cacheData){
                        data[x] = cacheData[x];
                    }

                    data['all_case_ids'] = 0;

                    //THIS IS MUST FIELD IN DOCK REPORT ACTIVITY REPORT!!!!!
                    //OTHERWISE, WE WILL GENT EMPTY RESULT
                    //data['sort1'] = "case number";

                    var requestObject = {
                        method: 'POST',
                        url: host+'/getReport?actionPath='+cacheData.action,
                        headers: {
                            'Content-Type': 'application/json;charset=utf-8'
                        },
                        data: data
                    };

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache['commonReportData'] = optionsData;
                            return optionsData;
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });
                    return promise;
                };

                service.getCommonReportFormData = function (reportName) {
                    var action = 'get'+reportName+'Query';
                    console.log ("sending action="+action);
                    var requestObject = {
                        method: 'GET',
                        url: host+"/"+action,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        }
                    };
                    console.log ("getCommonReportFormData is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache[reportName] = optionsData;
                            return service.cache[reportName];
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.getCommonMainData = function (actionName){

                    var requestObject = {
                        method: 'GET',
                        url: host+'/getCommonMainData?caseID='+service.cache['shortCaseNum']+"&action="+actionName,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        },
                        data: { }
                    };
                    console.log ("getCommonMainData is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache['componentData'] = {
                                componentData: optionsData.componentData,
                                componentDataDetails: optionsData.componentDataDetails,
                                componentName: optionsData.componentName,
                                billing:optionsData.billing
                            };
                            return service.cache['componentData'];
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                service.getCommonFormData = function (formName,action,courtId) {

                    let endUrl = `${host}${courtId}/case/${service.cache['shortCaseNum']}/${action}`;
                    var requestObject = {
                        method: 'GET',
                        url: endUrl,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                        }
                    };
                    console.log ("getCommonFormData is running!!");

                    var promise = $http(requestObject).then(
                        function(response){
                            var optionsData = response.data;
                            service.cache[formName] = optionsData;
                            return service.cache[formName];
                        },
                        function(queryFormData){
                            console.log ("having problem in fetching form data");
                            return[];
                        });

                    return promise;
                };

                return service;
            }])

    .factory('Base64', function () {
        /* jshint ignore:start */

        var keyStr = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';

        return {
            encode: function (input) {
                var output = "";
                var chr1, chr2, chr3 = "";
                var enc1, enc2, enc3, enc4 = "";
                var i = 0;

                do {
                    chr1 = input.charCodeAt(i++);
                    chr2 = input.charCodeAt(i++);
                    chr3 = input.charCodeAt(i++);

                    enc1 = chr1 >> 2;
                    enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
                    enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
                    enc4 = chr3 & 63;

                    if (isNaN(chr2)) {
                        enc3 = enc4 = 64;
                    } else if (isNaN(chr3)) {
                        enc4 = 64;
                    }

                    output = output +
                        keyStr.charAt(enc1) +
                        keyStr.charAt(enc2) +
                        keyStr.charAt(enc3) +
                        keyStr.charAt(enc4);
                    chr1 = chr2 = chr3 = "";
                    enc1 = enc2 = enc3 = enc4 = "";
                } while (i < input.length);

                return output;
            },

            decode: function (input) {
                var output = "";
                var chr1, chr2, chr3 = "";
                var enc1, enc2, enc3, enc4 = "";
                var i = 0;

                // remove all characters that are not A-Z, a-z, 0-9, +, /, or =
                var base64test = /[^A-Za-z0-9\+\/\=]/g;
                if (base64test.exec(input)) {
                    window.alert("There were invalid base64 characters in the input text.\n" +
                        "Valid base64 characters are A-Z, a-z, 0-9, '+', '/',and '='\n" +
                        "Expect errors in decoding.");
                }
                input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

                do {
                    enc1 = keyStr.indexOf(input.charAt(i++));
                    enc2 = keyStr.indexOf(input.charAt(i++));
                    enc3 = keyStr.indexOf(input.charAt(i++));
                    enc4 = keyStr.indexOf(input.charAt(i++));

                    chr1 = (enc1 << 2) | (enc2 >> 4);
                    chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
                    chr3 = ((enc3 & 3) << 6) | enc4;

                    output = output + String.fromCharCode(chr1);

                    if (enc3 != 64) {
                        output = output + String.fromCharCode(chr2);
                    }
                    if (enc4 != 64) {
                        output = output + String.fromCharCode(chr3);
                    }

                    chr1 = chr2 = chr3 = "";
                    enc1 = enc2 = enc3 = enc4 = "";

                } while (i < input.length);

                return output;
            }
        };

        /* jshint ignore:end */
    });