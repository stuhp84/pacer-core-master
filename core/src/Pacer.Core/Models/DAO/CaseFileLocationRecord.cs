﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseFileLocationRecord
    {

        [JsonProperty("CaseNumber")]
        public string CaseNumber { get; set; }

        [JsonProperty("Volume")]
        public string Volume { get; set; }

        [JsonProperty("CaseTitle")]
        public string CaseTitle { get; set; }

        [JsonProperty("Result")]
        public string Result { get; set; }
    }

}