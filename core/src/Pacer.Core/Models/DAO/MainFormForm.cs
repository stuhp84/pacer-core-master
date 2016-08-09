
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class MainFormForm
    {

        [JsonProperty("MainFormSelectFields")]
        public MainFormSelectField[] MainFormSelectFields { get; set; }

        [JsonProperty("MainFormNonSelectFields")]
        public MainFormNonSelectField[] MainFormNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
