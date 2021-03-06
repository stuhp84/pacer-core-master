﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DocketHeader
    {

        [JsonProperty("USCourt")]
        public string USCourt { get; set; }

        [JsonProperty("USCourtBranch")]
        public string USCourtBranch { get; set; }

        [JsonProperty("CaseTitle")]
        public string CaseTitle { get; set; }

        [JsonProperty("CaseNum")]
        public string CaseNum { get; set; }

        [JsonProperty("Appeal")]
        public string Appeal { get; set; }

        [JsonProperty("PartyCompanyName")]
        public string PartyCompanyName { get; set; }

        [JsonProperty("AssignedTo")]
        public string AssignedTo { get; set; }

        [JsonProperty("Cause")]
        public string Cause { get; set; }

        [JsonProperty("DateFiled")]
        public string DateFiled { get; set; }

        [JsonProperty("DateTerminated")]
        public string DateTerminated { get; set; }

        [JsonProperty("JuryDemand")]
        public string JuryDemand { get; set; }

        [JsonProperty("NatureOfSuit")]
        public string NatureOfSuit { get; set; }

        [JsonProperty("Jurisdiction")]
        public string Jurisdiction { get; set; }
    }

}
