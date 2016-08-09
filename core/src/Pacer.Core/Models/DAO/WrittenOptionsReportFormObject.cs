
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class WrittenOptionsReportFormObject
    {


        [JsonProperty("WrittenOptionsReportSelectOptionValues")]
        public WrittenOptionsReportSelectOptionValues WrittenOptionsReportSelectOptionValues { get; set; }

        [JsonProperty("WrittenOptionsReportForm")]
        public WrittenOptionsReportForm WrittenOptionsReportForm { get; set; }

    }

}
