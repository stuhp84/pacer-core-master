
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class HistoryDocumentsForm
    {

        [JsonProperty("HistoryDocumentsSelectFields")]
        public HistoryDocumentsSelectField[] HistoryDocumentsSelectFields { get; set; }

        [JsonProperty("HistoryDocumentsNonSelectFields")]
        public HistoryDocumentsNonSelectField[] HistoryDocumentsNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
