
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CivilCaseReportSelectOptionValues
    {

        [JsonProperty("office")]
        public string[][] Office { get; set; }

        [JsonProperty("case_type")]
        public string[][] CaseType { get; set; }

        [JsonProperty("nature_of_suit")]
        public string[][] NatureOfSuit { get; set; }

        [JsonProperty("cause")]
        public string[][] Cause { get; set; }

        [JsonProperty("jurisdic")]
        public string[][] Jurisdic { get; set; }

        [JsonProperty("case_flags")]
        public string[][] CaseFlags { get; set; }

        [JsonProperty("sort1")]
        public string[][] Sort1 { get; set; }

        [JsonProperty("sort2")]
        public string[][] Sort2 { get; set; }

        [JsonProperty("sort3")]
        public string[][] Sort3 { get; set; }
    }

}
