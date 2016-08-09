
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class HistoryDocumentsSelectOptionValues
    {

        [JsonProperty("sort1")]
        public string[][] Sort1 { get; set; }
    }

}
