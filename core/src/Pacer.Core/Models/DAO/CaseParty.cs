
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseParty
    {

        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("attorneys")]
        public CasePartyAttorney[] CasePartyAttorney { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }


    }

}
