
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DeadlinesHearingsForm
    {

        [JsonProperty("DeadlinesHearingsSelectFields")]
        public DeadlinesHearingsSelectField[] DeadlinesHearingsSelectFields { get; set; }

        [JsonProperty("DeadlinesHearingsNonSelectFields")]
        public DeadlinesHearingsNonSelectField[] DeadlinesHearingsNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
