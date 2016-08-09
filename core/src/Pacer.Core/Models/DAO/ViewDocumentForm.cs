
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class ViewDocumentForm
    {

        [JsonProperty("ViewDocumentSelectFields")]
        public object[] ViewDocumentSelectFields { get; set; }

        [JsonProperty("ViewDocumentNonSelectFields")]
        public ViewDocumentNonSelectField[] ViewDocumentNonSelectFields { get; set; }

        [JsonProperty("reportName")]
        public string ReportName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }

}
