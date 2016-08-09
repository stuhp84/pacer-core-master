
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CriminalCaseReportFormObject
    {


        [JsonProperty("CriminalCaseReportSelectOptionValues")]
        public CriminalCaseReportSelectOptionValues CriminalCaseReportSelectOptionValues { get; set; }

        [JsonProperty("CriminalCaseReportForm")]
        public CriminalCaseReportForm CriminalCaseReportForm { get; set; }

    }

}
