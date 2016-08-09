
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class Header
    {
        [JsonProperty("header1")]
        public string Header1 { get; set; }

        [JsonProperty("header2")]
        public string Header2 { get; set; }

        [JsonProperty("CaseNumShort")]
        public string CaseNumShort { get; set; }

        [JsonProperty("CaseNum")]
        public string CaseNum { get; set; }

        [JsonProperty("PartyName")]
        public string PartyName { get; set; }

        [JsonProperty("PartyRepresentative")]
        public string PartyRepresentative { get; set; }

        [JsonProperty("PartyReferral")]
        public string PartyReferral { get; set; }

        [JsonProperty("DateFiled")]
        public string DateFiled { get; set; }

        [JsonProperty("DateTerminated")]
        public string DateTerminated { get; set; }

        [JsonProperty("DateOfLastFiling")]
        public string DateOfLastFiling { get; set; }
		
		[JsonProperty("AssociatedCases")]
        public string AssociatedCases { get; set; }
    }

}
