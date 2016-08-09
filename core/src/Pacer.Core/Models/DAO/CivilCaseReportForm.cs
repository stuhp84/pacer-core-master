
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CivilCaseReportForm
    {

        [JsonProperty("CivilCaseReportSelectFields")]
        public CivilCaseReportSelectField[] CivilCaseReportSelectFields { get; set; }

        [JsonProperty("CivilCaseReportNonSelectFields")]
        public CivilCaseReportNonSelectField[] CivilCaseReportNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
