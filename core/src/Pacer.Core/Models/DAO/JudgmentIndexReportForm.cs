
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class JudgmentIndexReportForm
    {

        [JsonProperty("JudgmentIndexReportSelectFields")]
        public JudgmentIndexReportSelectField[] JudgmentIndexReportSelectFields { get; set; }

        [JsonProperty("JudgmentIndexReportNonSelectFields")]
        public JudgmentIndexReportNonSelectField[] JudgmentIndexReportNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
