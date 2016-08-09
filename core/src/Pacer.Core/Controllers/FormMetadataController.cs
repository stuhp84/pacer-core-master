using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pacer.Core.Models;
using Newtonsoft.Json;
using USCourts.AO.Epa.Pacer;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pacer.Core.Controllers
{
    [Route("[controller]")]
    public class FormMetadataController : Controller
    {
        public FormMetadataController(ICaseRepository injectedRepo)
        {
            caseRepository = injectedRepo;
        }

        public ICaseRepository caseRepository { get; set; }

        // GET courtId/searchqueryform
        [HttpGet("{courtId}/searchqueryform")]
        public MainFormObject MainQueryFormStructure(string courtId)
        {
            string uriPath = "getCommonFormData?action=MainForm";
            MainFormObject form = caseRepository.GetPacerData<MainFormObject>(uriPath, Request, Response);
            return form;
        }
         

        // GET courtId/filelocationform
        [HttpGet("{courtId}/filelocationform")]
        public CaseFileLocationFormObject CaseFileLocationFormStructure(string courtId)
        {
            return
                caseRepository.getCaseFileLocationFormStructure();
        }

        // GET courtId/deadlinesform
        [HttpGet("{courtId}/deadlinesform")]
        public DeadlinesHearingsFormObject DeadlinesFormStructure(string courtId)
        {
            return
                caseRepository.getDeadlinesFormStructure();
        }

        // GET courtId/docketreportform
        [HttpGet("{courtId}/docketreportform")]
        public DocketReportFormObject DocketReportFormStructure(string courtId)
        {
            return
                caseRepository.getDocketReportFormStructure();
        }

        // GET courtId/historydocumentform
        [HttpGet("{courtId}/historydocumentform")]
        public HistoryDocumentsFormObject HistoryDocumentsFormStructure(string courtId)
        {
            return
                caseRepository.getHistoryDocumentsFormStructure();
        }

        // GET courtId/relatedtransactionsform
        [HttpGet("{courtId}/relatedtransactionsform")]
        public RelatedTransactionsFormObject RelatedTransactionsFormStructure(string courtId)
        {
            return
                caseRepository.getRelatedTransactionsFormStructure();
        }

       
    }
}
