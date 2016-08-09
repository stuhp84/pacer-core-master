
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class RelatedTransactionsSelectOptionValues
    {

        [JsonProperty("do_type")]
        public string[][] DoType { get; set; }

        [JsonProperty("sort1")]
        public string[][] Sort1 { get; set; }
    }

}
