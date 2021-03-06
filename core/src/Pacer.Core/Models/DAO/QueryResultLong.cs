﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class QueryResultLong
    {

        [JsonProperty("CaseNumber")]
        public string[] CaseNumber { get; set; }

        [JsonProperty("Parties")]
        public string Parties { get; set; }

        [JsonProperty("CaseClosedDate")]
        public string CaseClosedDate { get; set; }
         
        [JsonProperty("CaseFiledDate")]
        public string CaseFiledDate { get; set; }

        [JsonProperty("NatureOfSuit")]
        public string NatureOfSuit { get; set; }
    }

}
