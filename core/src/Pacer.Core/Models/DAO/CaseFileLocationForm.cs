
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseFileLocationForm
    {

        [JsonProperty("CaseFileLocationSelectFields")]
        public object[] CaseFileLocationSelectFields { get; set; }

        [JsonProperty("CaseFileLocationNonSelectFields")]
        public CaseFileLocationNonSelectField[] CaseFileLocationNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
