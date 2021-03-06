
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class RelatedTransactionsForm
    {

        [JsonProperty("RelatedTransactionsSelectFields")]
        public RelatedTransactionsSelectField[] RelatedTransactionsSelectFields { get; set; }

        [JsonProperty("RelatedTransactionsNonSelectFields")]
        public RelatedTransactionsNonSelectField[] RelatedTransactionsNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
