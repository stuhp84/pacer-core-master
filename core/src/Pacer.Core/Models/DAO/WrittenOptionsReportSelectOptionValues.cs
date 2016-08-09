
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class WrittenOptionsReportSelectOptionValues
    {

        [JsonProperty("office")]
        public string[][] Office { get; set; }

        [JsonProperty("nsuit")]
        public string[][] Nsuit { get; set; }

        [JsonProperty("case_type")]
        public string[][] CaseType { get; set; }

        [JsonProperty("cause")]
        public string[][] Cause { get; set; }

        [JsonProperty("case_flags")]
        public string[][] CaseFlags { get; set; }

        [JsonProperty("Key1")]
        public string[][] Key1 { get; set; }
    }

}
