﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class Dates
    {

        [JsonProperty("Entered")]
        public string Entered { get; set; }

        [JsonProperty("Time")]
        public string Time { get; set; }

        [JsonProperty("Filed")]
        public string Filed { get; set; }

        [JsonProperty("Reopened")]
        public string Reopened { get; set; }
    }

}