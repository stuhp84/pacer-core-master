
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class WrittenOptionsReportSelectField
    {

        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        [JsonProperty("fieldLabel")]
        public string FieldLabel { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

}
