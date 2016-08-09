
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DeadlinesTable
    {

        [JsonProperty("DocNo")]
        public object DocNo { get; set; }

        [JsonProperty("DeadlineHearing")]
        public string[] DeadlineHearing { get; set; }

        [JsonProperty("EventFiled")]
        public string EventFiled { get; set; }

        [JsonProperty("DueSet")]
        public string DueSet { get; set; }

        [JsonProperty("Satisfied")]
        public string Satisfied { get; set; }

        [JsonProperty("Terminated")]
        public string Terminated { get; set; }
    }

}
