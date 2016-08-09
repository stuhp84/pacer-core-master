using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pacer.Core.Models
{
    public class DeadlinesHearingsFormPost
    {
        [JsonProperty("sort1")]
        public string Sort1 { get; set; }

        [JsonProperty("sort2")]
        public string Sort2 { get; set; }

        [JsonProperty("sort3")]
        public string Sort3 { get; set; }

        [JsonProperty("ChkPend")]
        public string ChkPend { get; set; }

        [JsonProperty("ChkTerm")]
        public string ChkTerm { get; set; }

        [JsonProperty("CGIPerl")]
        public string CGIPerl { get; set; }

    }
}
