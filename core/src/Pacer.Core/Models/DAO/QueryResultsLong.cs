﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class QueryResultsLong
    {

        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("queryResult")]
        public QueryResultLong[] QueryResult { get; set; }

        [JsonProperty("billing")]
        public Billing Billing { get; set; }

        [JsonProperty("sidebar")]
        public string Sidebar { get; set; }

        [JsonProperty("parsed")]
        public bool Parsed { get; set; }
    }

}