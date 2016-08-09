
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseSumHeader
    {

        [JsonProperty("Office")]
        public string Office { get; set; }

        [JsonProperty("Filed")]
        public string Filed { get; set; }

        [JsonProperty("JuryDemand")]
        public string JuryDemand { get; set; }

        [JsonProperty("Demand")]
        public string Demand { get; set; }

        [JsonProperty("NatureofSuit")]
        public string NatureofSuit { get; set; }

        [JsonProperty("Cause")]
        public string Cause { get; set; }

        [JsonProperty("Jurisdiction")]
        public string Jurisdiction { get; set; }

        [JsonProperty("Disposition")]
        public string Disposition { get; set; }

        [JsonProperty("County")]
        public string County { get; set; }

        [JsonProperty("Terminated")]
        public string Terminated { get; set; }

        [JsonProperty("Origin")]
        public string Origin { get; set; }

        [JsonProperty("Reopened")]
        public string Reopened { get; set; }

        [JsonProperty("LeadCase")]
        public string LeadCase { get; set; }

        [JsonProperty("RelatedCase")]
        public string RelatedCase { get; set; }

        [JsonProperty("OtherCourtCase")]
        public string OtherCourtCase { get; set; }

        [JsonProperty("DefCustodyStatus")]
        public string DefCustodyStatus { get; set; }

        [JsonProperty("Flags")]
        public string Flags { get; set; }
    }

}
