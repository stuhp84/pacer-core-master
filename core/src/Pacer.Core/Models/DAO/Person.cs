
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class Person
    {

        [JsonProperty("PartyName")]
        public string PartyName { get; set; }

        [JsonProperty("PartyCompany")]
        public string PartyCompany { get; set; }

        [JsonProperty("ExtraText")]
        public string ExtraText { get; set; }
    }

}
