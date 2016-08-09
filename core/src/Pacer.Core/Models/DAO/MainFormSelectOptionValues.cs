
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class MainFormSelectOptionValues
    {

        [JsonProperty("nature_suit")]
        public string[][] NatureSuit { get; set; }

        [JsonProperty("cause_action")]
        public string[][] CauseAction { get; set; }

        [JsonProperty("person_type")]
        public string[][] PersonType { get; set; }
    }

}
