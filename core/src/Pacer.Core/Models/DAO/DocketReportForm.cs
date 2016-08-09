
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DocketReportForm
    {

        [JsonProperty("DocketReportSelectFields")]
        public DocketReportSelectField[] DocketReportSelectFields { get; set; }

        [JsonProperty("DocketReportNonSelectFields")]
        public DocketReportNonSelectField[] DocketReportNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
