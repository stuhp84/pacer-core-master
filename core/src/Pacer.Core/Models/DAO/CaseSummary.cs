
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseSummary
    {

        [JsonProperty("header1")]
        public Header Header { get; set; }

        [JsonProperty("caseSumHeader")]
        public CaseSumHeader CaseSumHeader { get; set; }

        [JsonProperty("caseSumTable")]
        public CaseSumTable[] CaseSumTable { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }


    }

}
