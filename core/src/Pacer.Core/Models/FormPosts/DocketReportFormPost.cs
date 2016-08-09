using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pacer.Core.Models
{
    public class DocketReportFormPost
    {

            [JsonProperty("view_comb_doc_text")]
            public string ViewCombDocText { get; set; }

            [JsonProperty("all_case_ids")]
            public string AllCaseIds { get; set; }

            [JsonProperty("date_range_type")]
            public string DateRangeType { get; set; }

            [JsonProperty("date_from")]
            public string DateFrom { get; set; }

            [JsonProperty("date_to")]
            public string DateTo { get; set; }

            [JsonProperty("documents_numbered_from_")]
            public string DocumentsNumberedFrom { get; set; }

            [JsonProperty("documents_numbered_to_")]
            public string DocumentsNumberedTo { get; set; }

            [JsonProperty("list_of_parties_and_counsel")]
            public string ListOfPartiesAndCounsel { get; set; }

            [JsonProperty("terminated_parties")]
            public string TerminatedParties { get; set; }

            [JsonProperty("list_of_member_cases")]
            public string ListOfMemberCases { get; set; }

            [JsonProperty("output_format")]
            public string OutputFormat { get; set; }

            [JsonProperty("PreResetField")]
            public string PreResetField { get; set; }

            [JsonProperty("PreResetFields")]
            public string PreResetFields { get; set; }

            [JsonProperty("sort1")]
            public string Sort1 { get; set; }

            [JsonProperty("view_multi_docs")]
            public string ViewMultiDocs { get; set; }

        [JsonProperty("CGIPerl")]
        public string CGIPerl { get; set; }

    }
}
