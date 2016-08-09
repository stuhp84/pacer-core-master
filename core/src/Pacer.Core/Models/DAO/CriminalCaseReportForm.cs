
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CriminalCaseReportForm
    {

        [JsonProperty("CriminalCaseReportSelectFields")]
        public CriminalCaseReportSelectField[] CriminalCaseReportSelectFields { get; set; }

        [JsonProperty("CriminalCaseReportNonSelectFields")]
        public CriminalCaseReportNonSelectField[] CriminalCaseReportNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
