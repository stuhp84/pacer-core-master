using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USCourts.AO.Epa.Pacer
{
    public class CasePartyAttorney
    {
        [JsonProperty("persons")]
        public string[] Persons { get; set; }

        [JsonProperty("AttorneyToPersonList")]
        public AttorneyToPersonList[] AttorneyToPersonList { get; set; }

        [JsonProperty("Represent")]
        public string Represent { get; set; }
    }
}
