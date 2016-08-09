
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class Attorney
    {

        [JsonProperty("persons")]
        public string[][] Persons { get; set; }

        [JsonProperty("AttorneyRecord")]
        public AttorneyRecord AttorneyRecord { get; set; }

        [JsonProperty("Represent")]
        public string Represent { get; set; }
    }

}
