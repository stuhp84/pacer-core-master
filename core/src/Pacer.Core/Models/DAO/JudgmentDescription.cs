﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class JudgmentDescription
    {

        [JsonProperty("Infavorof")]
        public string Infavorof { get; set; }

        [JsonProperty("Against")]
        public string Against { get; set; }

        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("DocumentURL")]
        public string DocumentURL { get; set; }

        [JsonProperty("DocumentURLName")]
        public string DocumentURLName { get; set; }

        [JsonProperty("Interest")]
        public string Interest { get; set; }

        [JsonProperty("CourtCost")]
        public string CourtCost { get; set; }
    }

}
