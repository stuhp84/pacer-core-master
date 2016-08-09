
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CalendarEventsReportSelectOptionValues
    {

        [JsonProperty("office")]
        public string[][] Office { get; set; }

        [JsonProperty("nature_suit")]
        public string[][] NatureSuit { get; set; }

        [JsonProperty("SelectHearings")]
        public string[][] SelectHearings { get; set; }

        [JsonProperty("Sort")]
        public string[][] Sort { get; set; }
    }

}
