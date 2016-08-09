using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pacer.Core.Models.SimpleDAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using USCourts.AO.Epa.Pacer;

namespace Pacer.Core.Models
{
    

    public class CaseRepository : ICaseRepository
    {
        string pacerDataServerURL = "http://localhost:3000/";

        async public Task<string> Authenticate(string uid, string password, HttpResponse UIResponse)
        {
            LoginFormPost credData = new LoginFormPost();
            credData.login = uid;
            credData.key = password;
            credData.button1 = "Login";

            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            using (var client = new HttpClient(handler))
            {
                string uriPath = pacerDataServerURL+"login";
                HttpResponseMessage response = await client.PostAsJsonAsync<LoginFormPost>(uriPath, credData);
                if (response.IsSuccessStatusCode)
                {
                    Uri uri = new Uri(uriPath);
                    IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
                    foreach (Cookie cookie in responseCookies)
                    {
                        Console.WriteLine(cookie.Name + ": " + cookie.Value);
                        UIResponse.Cookies.Append(cookie.Name, cookie.Value);
                    }

                    return new JObject { { "result", true } }.ToString();
                }
            }
            return  new JObject { { "result", false } }.ToString(); ;
        }

        string readJsonFile (string fileName)
        {
            string readContents = "";
            try
            {
                string path = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\MockData\" + fileName);

                readContents = File.ReadAllText (path);
                Console.WriteLine(readContents);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return readContents;
        }

        byte[] GetBytes(string str)
        {
           // await FetchUrl<QueryResults>("", "", null);

            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        async Task<PacerDataType> FetchUrl<PacerDataType>(string uriPath, HttpRequest UIrequest, HttpResponse UIresponse)
        {
            Uri uri = new Uri(pacerDataServerURL);
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            foreach (KeyValuePair<string, string> entry in UIrequest.Cookies)
            {
                Console.WriteLine(entry.Key +":"+ entry.Value);
                handler.CookieContainer.Add(uri, new Cookie(entry.Key, entry.Value));
            }
          
            using (var client = new HttpClient(handler))
            {
                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(pacerDataServerURL+uriPath);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    PacerDataType pacerData = JsonConvert.DeserializeObject<PacerDataType>(json);
                    return pacerData;
                }
                return default(PacerDataType);
            }
       }

        public async Task<PacerOutDataType> PostToURL<PacerInDataType, PacerOutDataType>(PacerInDataType postData, string uriPath,HttpRequest UIrequest, HttpResponse UIresponse)
        {
            Uri uri = new Uri(pacerDataServerURL);
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            foreach (KeyValuePair<string, string> entry in UIrequest.Cookies)
            {
                handler.CookieContainer.Add(uri, new Cookie(entry.Key, entry.Value));
            }

            using (var client = new HttpClient(handler))
            {
                string fullUriPath = pacerDataServerURL + uriPath;
                string json = JsonConvert.SerializeObject(postData);
                HttpResponseMessage response = await client.PostAsync(fullUriPath, new StringContent(json, Encoding.UTF8, "application/json"));
                
                if (response.IsSuccessStatusCode)
                {
                    string strReponse = await response.Content.ReadAsStringAsync();
                    PacerOutDataType pacerOut = JsonConvert.DeserializeObject<PacerOutDataType>(strReponse);

                    return pacerOut;
                }
            }
            return default(PacerOutDataType);
        }

        public T GetPacerData<T>(string partialPath, HttpRequest request, HttpResponse response)
        {
            T qResult = default(T);
            qResult = FetchUrl<T>(partialPath, request, response).Result;
            return qResult;
        }

        public QueryResultsShort getMainQueryResults2()
        { 
            string fileContents = readJsonFile("getReportJsonSearchResults.json");
            QueryResultsShort qResult = JsonConvert.DeserializeObject<QueryResultsShort>(fileContents);
            return qResult;
        }

        public CaseFileLocationFormObject getCaseFileLocationFormStructure()
        {
            string fileContents = readJsonFile("CaseFileLocationForm.json");
            CaseFileLocationFormObject qResult = JsonConvert.DeserializeObject<CaseFileLocationFormObject>(fileContents);
            return qResult;
        }
        public DeadlinesHearingsFormObject getDeadlinesFormStructure()
        {
            string fileContents = readJsonFile("DeadlinesHearingsForm.json");
            DeadlinesHearingsFormObject qResult = JsonConvert.DeserializeObject<DeadlinesHearingsFormObject>(fileContents);
            return qResult;
        }
        public DocketReportFormObject getDocketReportFormStructure()
        {
            string fileContents = readJsonFile("DocketReportForm.json");
            DocketReportFormObject qResult = JsonConvert.DeserializeObject<DocketReportFormObject>(fileContents);
            return qResult;
        }
        public HistoryDocumentsFormObject getHistoryDocumentsFormStructure()
        {
            string fileContents = readJsonFile("HistoryDocumentsForm.json");
            HistoryDocumentsFormObject qResult = JsonConvert.DeserializeObject<HistoryDocumentsFormObject>(fileContents);
            return qResult;
        }
        public RelatedTransactionsFormObject getRelatedTransactionsFormStructure()
        {
            string fileContents = readJsonFile("RelatedTransactionsForm.json");
            RelatedTransactionsFormObject qResult = JsonConvert.DeserializeObject<RelatedTransactionsFormObject>(fileContents);
            return qResult;
        }

    }
}
