
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class WrittenOptionsReportNonSelectField
    {

        [JsonProperty("fieldLabel")]
        public string FieldLabel { get; set; }

        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("fieldValue")]
        public object FieldValue { get; set; }
    }

}
