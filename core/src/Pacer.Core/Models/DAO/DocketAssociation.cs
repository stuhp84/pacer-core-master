
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DocketAssociation
    {

        [JsonProperty("person")]
        public Person Person { get; set; }

        [JsonProperty("represent")]
        public string Represent { get; set; }

        [JsonProperty("attorneys")]
        public DocketAttorney[] Attorneys { get; set; }
    }

}
