
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace USCourts.AO.Epa.Pacer
{

    public class CaseDocketReport
    {

        [JsonProperty("header")]
        public DocketHeader Header { get; set; }

        [JsonProperty("docketTable")]
        public DocketTable[] DocketTable { get; set; }

        [JsonProperty("associations")]
        public DocketAssociation[] Associations { get; set; }

        
        [JsonProperty("billing")]
        public Billing Billing { get; set; }


    }

}
