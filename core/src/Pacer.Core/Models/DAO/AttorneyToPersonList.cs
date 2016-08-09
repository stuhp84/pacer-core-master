
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class AttorneyToPersonList
    {

        [JsonProperty("Fax")]
        public string Fax { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("AssignedDate")]
        public string AssignedDate { get; set; }

        [JsonProperty("extraInfo1")]
        public string ExtraInfo1 { get; set; }

        [JsonProperty("extraInfo2")]
        public string ExtraInfo2 { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Company")]
        public string Company { get; set; }

        [JsonProperty("Address")]
        public string[] Address { get; set; }
    }

}
