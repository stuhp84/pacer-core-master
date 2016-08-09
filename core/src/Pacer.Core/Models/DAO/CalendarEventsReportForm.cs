
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CalendarEventsReportForm
    {

        [JsonProperty("CalendarEventsReportSelectFields")]
        public CalendarEventsReportSelectField[] CalendarEventsReportSelectFields { get; set; }

        [JsonProperty("CalendarEventsReportNonSelectFields")]
        public CalendarEventsReportNonSelectField[] CalendarEventsReportNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
