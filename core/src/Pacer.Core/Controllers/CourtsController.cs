using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pacer.Core.Models;
using USCourts.AO.Epa.Pacer;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Pacer.Core.Models.SimpleDAO;



// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pacer.Core.Controllers
{

    [Route("[controller]")]
    public class CourtsController : Controller
    {
        private IConfiguration config;
        private string xPacerActionHeaderName;

        public CourtsController (ICaseRepository injectedRepo,IConfiguration config)
        {
            caseRepository = injectedRepo;
            this.config = config;
            xPacerActionHeaderName = config.GetSection("Pacer").GetSection("xPacerActionHeaderName").Value;
        }

        public ICaseRepository caseRepository { get; set; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "No Courts Home Page" };
        }

        // GET courts/5
        [HttpGet("{courtId}")]
        public string GetCourt(string courtId)
        {
            return $"Courts Home Page for courtId:{courtId}" ;
        }

        // GET courts/5/case/15/attorney
        [HttpGet("{courtId}/case/{caseId}/attorney")]
        public CaseAttorney GetAttorney(string courtId, string caseId)
        {
            string uriPath = "getAttorneyJson?caseID=" + caseId;
            CaseAttorney form = caseRepository.GetPacerData<CaseAttorney>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/case/15/alias
        [HttpGet("{courtId}/case/{caseId}/alias")]
        public CaseAlias GetAlias(string courtId, string caseId)
        {
            string uriPath = "getAliasJson?caseID=" + caseId;
            CaseAlias form = caseRepository.GetPacerData<CaseAlias>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/case/15/associatedcases
        [HttpGet("{courtId}/case/{caseId}/associatedcases")]
        public AssociatedCases GetAssociatedCases(string courtId, string caseId)
        {
            string uriPath = "getAssociatedCasesJson?caseID=" + caseId;
            AssociatedCases form = caseRepository.GetPacerData<AssociatedCases>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/case/15/casesummary
        [HttpGet("{courtId}/case/{caseId}/casesummary")]
        public CaseSummary GetCaseSummary(string courtId, string caseId)
        {
            string uriPath = "getCaseSummaryJson?caseID=" + caseId;
            CaseSummary form = caseRepository.GetPacerData<CaseSummary>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/case/15/filers
        [HttpGet("{courtId}/case/{caseId}/filers")]
        public CaseFilers GetFilers(string courtId, string caseId)
        {
            string uriPath = "getFilersJson?caseID=" + caseId;
            CaseFilers form = caseRepository.GetPacerData<CaseFilers>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/case/15/parties
        [HttpGet("{courtId}/case/{caseId}/parties")]
        public CaseParty GetParties(string courtId, string caseId)
        {
            string uriPath = "getPartyJson?caseID=" + caseId;
            CaseParty form = caseRepository.GetPacerData<CaseParty>(uriPath, Request, Response);
            return form;
        }
        
        // GET courts/5/case/15/status
        [HttpGet("{courtId}/case/{caseId}/status")]
        public CaseStatus GetStatus(string courtId, string caseId)
        {
            string uriPath = "getStatusJson?caseID=" + caseId;
            CaseStatus form = caseRepository.GetPacerData<CaseStatus>(uriPath, Request, Response);
            return form;
        }

        //Allform posts starts from here

        // GET courts/5/getmainformstructure
        [HttpGet("{courtId}/case/{caseId}/getmainformstructure")]
        public MainFormObject GetMainQueryFormStructure(string courtId, string caseId)
        {
            string uriPath = "getCommonFormData?action=MainForm";
            MainFormObject form = caseRepository.GetPacerData<MainFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getcasefilelocationstructure
        [HttpGet("{courtId}/case/{caseId}/getcasefilelocationstructure")]
        public CaseFileLocationFormObject GetGetCaseFileLocationStructure(string courtId, string caseId)
        {
            string uriPath = "getCommonFormData?action=CaseFileLocation&caseID="+caseId;
            CaseFileLocationFormObject form = caseRepository.GetPacerData<CaseFileLocationFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getcasedeadlinestructure
        [HttpGet("{courtId}/case/{caseId}/getcasedeadlinestructure")]
        public DeadlinesHearingsFormObject GetCaseDeadlineFormStructure(string courtId, string caseId)
        {
            string uriPath = "getCommonFormData?action=DeadlinesHearings&caseID="+caseId;
            DeadlinesHearingsFormObject form = caseRepository.GetPacerData<DeadlinesHearingsFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getcasehistorytructure
        [HttpGet("{courtId}/case/{caseId}/getcasehistorytructure")]
        public HistoryDocumentsFormObject GetCaseHistoryFormStructure(string courtId, string caseId)
        {
            string uriPath = "getCommonFormData?action=HistoryDocuments&caseID=" + caseId;
            HistoryDocumentsFormObject form = caseRepository.GetPacerData<HistoryDocumentsFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getcaserelatedtransactionstructure
        [HttpGet("{courtId}/case/{caseId}/getcaserelatedtransactionstructure")]
        public RelatedTransactionsFormObject GetCaseRelatedTransactionsFormStructure(string courtId, string caseId)
        {
            string uriPath = "getCommonFormData?action=RelatedTransactions&caseID=" + caseId;
            RelatedTransactionsFormObject form = caseRepository.GetPacerData<RelatedTransactionsFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getcaseviewdocumentstructure
        [HttpGet("{courtId}/case/{caseId}/getcaseviewdocumentstructure")]
        public ViewDocumentFormObject GetCaseViewDocumentFormStructure(string courtId, string caseId)
        {
            string uriPath = "getCommonFormData?action=ViewDocument&caseID=" + caseId;
            ViewDocumentFormObject form = caseRepository.GetPacerData<ViewDocumentFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getdocketreportstructure
        [HttpGet("{courtId}/case/{caseId}/getdocketreportstructure")]
        public DocketReportFormObject GetDocketReportFormStructure(string courtId, string caseId)
        { 
            string uriPath = "getCommonFormData?action=DocketReport&caseID=" + caseId;
            DocketReportFormObject form = caseRepository.GetPacerData<DocketReportFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getcriminalcasereportstructure
        [HttpGet("{courtId}/case/{caseId}/getcriminalcasereportstructure")]
        public CriminalCaseReportFormObject GetCriminalCaseReportStructure(string courtId, string caseId)
        {
            string uriPath = "getCriminalCaseReportQuery";
            CriminalCaseReportFormObject form = caseRepository.GetPacerData<CriminalCaseReportFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getcivilcasereportstructure
        [HttpGet("{courtId}/case/{caseId}/getcivilcasereportstructure")]
        public CivilCaseReportFormObject GetCivilCaseReportStructure(string courtId, string caseId)
        {
            string uriPath = "getCivilCaseReportQuery";
            CivilCaseReportFormObject form = caseRepository.GetPacerData<CivilCaseReportFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getcalendareventsreportstructure
        [HttpGet("{courtId}/case/{caseId}/getcalendareventsreportstructure")]
        public CalendarEventsReportFormObject GetCalendarEventsReportStructure(string courtId, string caseId)
        {
            string uriPath = "getCalendarEventsReportQuery";
            CalendarEventsReportFormObject form = caseRepository.GetPacerData<CalendarEventsReportFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getdocketactivityreportstructure
        [HttpGet("{courtId}/case/{caseId}/getdocketactivityreportstructure")]
        public DocketActivityReportFormObject GetDocketActivityReportStructure(string courtId, string caseId)
        {
            string uriPath = "getDocketActivityReportQuery";
            DocketActivityReportFormObject form = caseRepository.GetPacerData<DocketActivityReportFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getwrittenoptionsreportstructure
        [HttpGet("{courtId}/case/{caseId}/getwrittenoptionsreportstructure")]
        public WrittenOptionsReportFormObject GetWrittenOptionsReportStructure(string courtId, string caseId)
        {
            string uriPath = "getWrittenOptionsReportQuery";
            WrittenOptionsReportFormObject form = caseRepository.GetPacerData<WrittenOptionsReportFormObject>(uriPath, Request, Response);
            return form;
        }

        // GET courts/5/getjudgmentindexreportstructure
        [HttpGet("{courtId}/case/{caseId}/getjudgmentindexreportstructure")]
        public JudgmentIndexReportFormObject GetJudgmentIndexStructure(string courtId, string caseId)
        {
            string uriPath = "getJudgmentIndexReportFormQuery";
            JudgmentIndexReportFormObject form = caseRepository.GetPacerData<JudgmentIndexReportFormObject>(uriPath, Request, Response);
            return form;
        }
        //

        //Allform posts ends here

        // GET courts/5/getcasenum/perl-script-xxx
        [HttpGet("{courtId}/getcasenum/{perlcgi}")]
        public CaseNum GetCaseNum(string courtId, string perlcgi)
        {
            string uriPath = "getCaseNum?" + perlcgi;
            CaseNum form = caseRepository.GetPacerData<CaseNum>(uriPath, Request, Response);
            return form;
        }

                
        // GET courts/5/getcaselandingpage/perl-script-xxx
        [HttpGet("{courtId}/getcaselandingpage/{perlcgi}")]
        public Header GetCaseLandingPage(string courtId, string perlcgi)
        {
            string uriPath = "getCaseLandingPageData?" + perlcgi;
            Header form = caseRepository.GetPacerData<Header>(uriPath, Request, Response);
            return form;
        }

        [HttpGet("{courtId}/searchbycasenum/{casenum}")]
        public CaseAlias SearchByCaseNum(string courtId, string casenum)
        {
            string uriPath = "searchByCaseNumber?caseNumber=" + casenum;
            CaseAlias form = caseRepository.GetPacerData<CaseAlias>(uriPath, Request, Response);
            return form;
        }

        [HttpGet("{courtId}/caselookup/{casenum}")]
        public CaseLookupPairs GetCaseLookupPairs(string courtId, string casenum)
        {
            string uriPath = "lookupCaseNumber?caseNumber=" + casenum;
            CaseLookupPairs form = caseRepository.GetPacerData<CaseLookupPairs>(uriPath, Request, Response);
            return form;
        }

        [HttpGet("{courtId}/searchbyname/{name}")]
        public QueryResultsShort SearchByBusinessName(string courtId, string name)
        {
            string uriPath = "searchByBusinessName?name=" + name;
            QueryResultsShort form = caseRepository.GetPacerData<QueryResultsShort>(uriPath, Request, Response);
            return form;
        }


        // POST courts/5/authenticate
        [HttpPost("{courtId}/authenticate")]
        public string Authenticate([FromBody]LoginFormPost form,string courtId)
        {
            string username = form.login;
            string key = form.key;
            string result = caseRepository.Authenticate(username,key,this.Response).Result;

            return result;
        }
  
         // POST courts/5/searchcaseslong
        [HttpPost("{courtId}/searchcaseslong")]
        public QueryResultsLong MainQueryPostLong([FromBody]QueryResultsPost formData)
        {
            QueryResultsLong qResult = caseRepository.PostToURL<QueryResultsPost, QueryResultsLong>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        // POST courts/5/searchcasesshort
        [HttpPost("{courtId}/searchcasesshort")]
        public QueryResultsShort MainQueryPostShort([FromBody]QueryResultsPost formData)
        {
            QueryResultsShort qResult = caseRepository.PostToURL<QueryResultsPost, QueryResultsShort>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        //process post requests

        // POST courts/5/casefilelocationresults
        [HttpPost("{courtId}/casefilelocationresults")]
        public CaseFileLocation CaseFileLocations([FromBody]CaseFileLocationFormPost formData)
        {
            CaseFileLocation qResult = caseRepository.PostToURL<CaseFileLocationFormPost, CaseFileLocation>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        // POST courts/5/deadlinesresults
        [HttpPost("{courtId}/deadlinesresults")]
        public CaseDeadlinesHearings DeadlinesHearings([FromBody]CaseFileLocationFormPost formData)
        {
            CaseDeadlinesHearings qResult = caseRepository.PostToURL<CaseFileLocationFormPost, CaseDeadlinesHearings>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        [HttpPost("{courtId}/getdocketreportresults")]
        public CaseDocketReport GetDocketReport([FromBody]DocketReportFormPost formData)
        {
            CaseDocketReport qResult = caseRepository.PostToURL<DocketReportFormPost, CaseDocketReport>(formData, "getReportJson", Request, Response).Result;
            return qResult;          
        }


        [HttpPost("{courtId}/gethistorydocumentsresults")]
        public CaseHistory GetHistoryDocuments([FromBody]HistoryDocumentsFormPost formData)
        {
            CaseHistory qResult = caseRepository.PostToURL<HistoryDocumentsFormPost, CaseHistory>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        [HttpPost("{courtId}/getrelatedtransactionsresults")]
        public CaseRelatedTransactions GetRelatedTransactions([FromBody]RelatedTransactionsFormPost formData)
        {
            CaseRelatedTransactions qResult = caseRepository.PostToURL<RelatedTransactionsFormPost, CaseRelatedTransactions>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        [HttpPost("{courtId}/getwrittenoptionsreport")]
        public WrittenOptionsReport GetWrittenOptionsReport([FromBody]WrittenOptionsReportFormPost formData)
        {
            WrittenOptionsReport qResult = caseRepository.PostToURL<WrittenOptionsReportFormPost, WrittenOptionsReport>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        [HttpPost("{courtId}/getcriminalcasesreport")]
        public CriminalCaseReport GetCriminalCasesReport([FromBody]CriminalCaseReportFormPost formData)
        {
            CriminalCaseReport qResult = caseRepository.PostToURL<CriminalCaseReportFormPost, CriminalCaseReport>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        [HttpPost("{courtId}/getcivilcasesreport")]
        public CivilCaseReport GetCivilCasesReport([FromBody]CivilCaseReportFormPost formData)
        {
            CivilCaseReport qResult = caseRepository.PostToURL<CivilCaseReportFormPost, CivilCaseReport>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        
        [HttpPost("{courtId}/getjudgmentindexreport")]
        public JudgementIndexReport GetJudgmentIndexReport([FromBody]JudgmentIndexReportFormPost formData)
        {
            JudgementIndexReport qResult = caseRepository.PostToURL<JudgmentIndexReportFormPost, JudgementIndexReport>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        [HttpPost("{courtId}/getcalendareventsreport")]
        public CalendarEventsReport GetCalendarEventsReport([FromBody]CalendarEventsReportFormPost formData)
        {
            CalendarEventsReport qResult = caseRepository.PostToURL<CalendarEventsReportFormPost, CalendarEventsReport>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }
        [HttpPost("{courtId}/getdocketactivityreport")]
        public DocketActivityReport GetDocketActivityReport([FromBody]DocketActivityReportFormPost formData)
        {
            DocketActivityReport qResult = caseRepository.PostToURL<DocketActivityReportFormPost, DocketActivityReport>(formData, "getReportJson", Request, Response).Result;
            return qResult;
        }

        //process post requests 


        // POST courts/5/case/15/deadlineshearingspost
        [HttpPost("{courtId}/case/{caseId}/deadlineshearingspost")]
        public string DeadlinesHearingsPost([FromBody]DeadlinesHearingsFormPost value)
        {
            return $"DeadlinesHearingsPost ";
        }

        // POST courts/5/case/15/docketreportpost
        [HttpPost("{courtId}/case/{caseId}/ddocketreportpost")]
        public string DocketReportPost([FromBody]DocketReportFormPost value)
        {
            return $"DocketReportPost ";
        }

        // POST courts/5/case/15/historydocumentspost
        [HttpPost("{courtId}/case/{caseId}/historydocumentspost")]
        public string HistoryDocumentsPost([FromBody]HistoryDocumentsFormPost value)
        {
            return $"HistoryDocumentsPost ";
        }

        // POST courts/5/case/15/relatedtransactionstspost
        [HttpPost("{courtId}/case/{caseId}/relatedtransactionstspost")]
        public string RelatedTransactionsPost([FromBody]RelatedTransactionsFormPost value)
        {
            return $"RelatedTransactionsPost ";
        }
    }
}
