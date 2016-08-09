
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DocketActivityReportForm
    {

        [JsonProperty("DocketActivityReportSelectFields")]
        public DocketActivityReportSelectField[] DocketActivityReportSelectFields { get; set; }

        [JsonProperty("DocketActivityReportNonSelectFields")]
        public DocketActivityReportNonSelectField[] DocketActivityReportNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
