
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DocketReportFormObject
    {


        [JsonProperty("DocketReportSelectOptionValues")]
        public DocketReportSelectOptionValues DocketReportSelectOptionValues { get; set; }

        [JsonProperty("DocketReportForm")]
        public DocketReportForm DocketReportForm { get; set; }

    }

}
