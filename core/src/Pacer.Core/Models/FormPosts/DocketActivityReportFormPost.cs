﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DocketActivityReportFormPost
    {

        [JsonProperty("all_case_ids")]
        public string AllCaseIds { get; set; }

        [JsonProperty("case_num")]
        public string CaseNum { get; set; }

        [JsonProperty("office")]
        public string Office { get; set; }

        [JsonProperty("case_type")]
        public string CaseType { get; set; }

        [JsonProperty("event_category")]
        public string EventCategory { get; set; }

        [JsonProperty("case_flags")]
        public string CaseFlags { get; set; }

        [JsonProperty("filed_from")]
        public string FiledFrom { get; set; }

        [JsonProperty("filed_to")]
        public string FiledTo { get; set; }

        [JsonProperty("date_range_limit")]
        public string DateRangeLimit { get; set; }

        [JsonProperty("docket_text")]
        public string DocketText { get; set; }

        [JsonProperty("sort1")]
        public string Sort1 { get; set; }

        [JsonProperty("sort2")]
        public string Sort2 { get; set; }

        [JsonProperty("CGIPerl")]
        public string CGIPerl { get; set; }
    }

}
