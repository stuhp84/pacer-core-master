
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseDeadlinesHearings
    {

        [JsonProperty("header1")]
        public Header Header { get; set; }

        [JsonProperty("deadlinesTable")]
        public DeadlinesTable[] DeadlinesTable { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }


    }

}
