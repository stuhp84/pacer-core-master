
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseSumTable
    {

        [JsonProperty("Plaintiff")]
        public string Plaintiff { get; set; }

        [JsonProperty("represent")]
        public string Represent { get; set; }

        [JsonProperty("attorney")]
        public string Attorney { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("Defendant")]
        public string Defendant { get; set; }

        [JsonProperty("Mediator")]
        public string Mediator { get; set; }
    }

}
