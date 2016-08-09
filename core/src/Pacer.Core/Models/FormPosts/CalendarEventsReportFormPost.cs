﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CalendarEventsReportFormPost
    {

        [JsonProperty("all_case_ids")]
        public string AllCaseIds { get; set; }

        [JsonProperty("case_num")]
        public string CaseNum { get; set; }

        [JsonProperty("office")]
        public string[] Office { get; set; }

        [JsonProperty("nature_suit")]
        public string[] NatureSuit { get; set; }

        [JsonProperty("SelectHearings")]
        public string[] SelectHearings { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        [JsonProperty("SchedTime")]
        public string SchedTime { get; set; }

        [JsonProperty("include_docket_text")]
        public string IncludeDocketText { get; set; }

        [JsonProperty("include_closed_cases")]
        public string IncludeClosedCases { get; set; }

        [JsonProperty("display_term_parties")]
        public string DisplayTermParties { get; set; }

        [JsonProperty("Sort")]
        public string[] Sort { get; set; }

        [JsonProperty("RptDeputy")]
        public string RptDeputy { get; set; }

        [JsonProperty("RptReport")]
        public string RptReport { get; set; }

        [JsonProperty("RptJudge")]
        public string RptJudge { get; set; }

        [JsonProperty("RptLocation")]
        public string RptLocation { get; set; }

        [JsonProperty("RptText")]
        public string RptText { get; set; }

        [JsonProperty("CGIPerl")]
        public string CGIPerl { get; set; }
    }

}
