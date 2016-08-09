
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class WrittenOptionsReportForm
    {

        [JsonProperty("WrittenOptionsReportSelectFields")]
        public WrittenOptionsReportSelectField[] WrittenOptionsReportSelectFields { get; set; }

        [JsonProperty("WrittenOptionsReportNonSelectFields")]
        public WrittenOptionsReportNonSelectField[] WrittenOptionsReportNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
