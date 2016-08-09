using Microsoft.AspNetCore.Http;
using Pacer.Core.Models.SimpleDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USCourts.AO.Epa.Pacer;

namespace Pacer.Core.Models
{
    public interface ICaseRepository
    {
        /*
            void Add(Book book);
            IEnumerable<Book> GetAll();
            Book FindCases(string id);
            Book Remove(string id);
            void Update(Book book);
        */

        T GetPacerData<T>(string partialPath, HttpRequest request, HttpResponse response);

        Task<string> Authenticate(string uid, string password,HttpResponse response);

        Task<PacerOutDataType> PostToURL<PacerInDataType, PacerOutDataType>(PacerInDataType postData, string uriPath, HttpRequest UIrequest, HttpResponse UIresponse);

        CaseFileLocationFormObject getCaseFileLocationFormStructure();
        DeadlinesHearingsFormObject getDeadlinesFormStructure();
        DocketReportFormObject getDocketReportFormStructure();
        HistoryDocumentsFormObject getHistoryDocumentsFormStructure();
        RelatedTransactionsFormObject getRelatedTransactionsFormStructure();
    }
}
