
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseMainQuery
    {

        [JsonProperty("header")]
        public string[] Header { get; set; }

        [JsonProperty("queryResult")]
        public QueryResultLong[] QueryResult { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }


    }

}
