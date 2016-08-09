
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class HistoryTable
    {

        [JsonProperty("DocNo")]
        public string[] DocNo { get; set; }

        [JsonProperty("Dates")]
        public string Dates { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("docketText")]
        public string DocketText { get; set; }
    }

}
