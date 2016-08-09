
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DocketActivityReportFormObject
    {


        [JsonProperty("DocketActivityReportSelectOptionValues")]
        public DocketActivityReportSelectOptionValues DocketActivityReportSelectOptionValues { get; set; }

        [JsonProperty("DocketActivityReportForm")]
        public DocketActivityReportForm DocketActivityReportForm { get; set; }

    }

}
