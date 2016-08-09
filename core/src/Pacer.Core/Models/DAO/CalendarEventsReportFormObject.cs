
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CalendarEventsReportFormObject
    {


        [JsonProperty("CalendarEventsReportSelectOptionValues")]
        public CalendarEventsReportSelectOptionValues CalendarEventsReportSelectOptionValues { get; set; }

        [JsonProperty("CalendarEventsReportForm")]
        public CalendarEventsReportForm CalendarEventsReportForm { get; set; }

    }

}
