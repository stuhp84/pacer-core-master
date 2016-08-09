
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DocketActivityReportSelectOptionValues
    {

        [JsonProperty("office")]
        public string[][] Office { get; set; }

        [JsonProperty("case_type")]
        public string[][] CaseType { get; set; }

        [JsonProperty("event_category")]
        public string[][] EventCategory { get; set; }

        [JsonProperty("case_flags")]
        public string[][] CaseFlags { get; set; }

        [JsonProperty("sort1")]
        public string[][] Sort1 { get; set; }

        [JsonProperty("sort2")]
        public string[][] Sort2 { get; set; }
    }

}
