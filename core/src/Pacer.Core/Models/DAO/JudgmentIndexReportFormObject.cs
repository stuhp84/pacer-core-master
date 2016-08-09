
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class JudgmentIndexReportFormObject
    {


        [JsonProperty("JudgmentIndexReportSelectOptionValues")]
        public JudgmentIndexReportSelectOptionValues JudgmentIndexReportSelectOptionValues { get; set; }

        [JsonProperty("JudgmentIndexReportForm")]
        public JudgmentIndexReportForm JudgmentIndexReportForm { get; set; }

    }

}
