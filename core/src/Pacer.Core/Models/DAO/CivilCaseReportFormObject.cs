
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CivilCaseReportFormObject
    {


        [JsonProperty("CivilCaseReportSelectOptionValues")]
        public CivilCaseReportSelectOptionValues CivilCaseReportSelectOptionValues { get; set; }

        [JsonProperty("CivilCaseReportForm")]
        public CivilCaseReportForm CivilCaseReportForm { get; set; }

    }

}
