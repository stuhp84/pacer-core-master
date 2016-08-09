
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class JudgmentIndexReportSelectOptionValues
    {

        [JsonProperty("Key1")]
        public string[][] Key1 { get; set; }
    }

}
