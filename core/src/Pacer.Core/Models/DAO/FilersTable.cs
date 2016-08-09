
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class FilersTable
    {

        [JsonProperty("Name")]
        public string[] Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Added")]
        public string Added { get; set; }

        [JsonProperty("Terminated")]
        public string Terminated { get; set; }
    }

}
