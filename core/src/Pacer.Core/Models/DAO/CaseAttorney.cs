
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseAttorney
    {

        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("attorneys")]
        public Attorney[] Attorneys { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }


    }

}
