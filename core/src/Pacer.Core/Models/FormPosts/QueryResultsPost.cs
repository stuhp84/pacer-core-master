
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pacer.Core.Models
{

    public class QueryResultsPost
    {

        [JsonProperty("all_case_ids")]
        public string AllCaseIds { get; set; }

        [JsonProperty("case_num")]
        public string CaseNum { get; set; }

        [JsonProperty("filed_from")]
        public string FiledFrom { get; set; }

        [JsonProperty("filed_to")]
        public string FiledTo { get; set; }

        [JsonProperty("lastentry_from")]
        public string LastentryFrom { get; set; }

        [JsonProperty("lastentry_to")]
        public string LastentryTo { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("nature_suit")]
        public string NatureSuit { get; set; }

        [JsonProperty("cause_action")]
        public string CauseAction { get; set; }

        [JsonProperty("person_type")]
        public string PersonType { get; set; }

        [JsonProperty("CGIPerl")]
        public string CGIPerl { get; set; }
        
    }

}
