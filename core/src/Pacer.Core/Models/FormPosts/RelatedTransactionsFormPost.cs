using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pacer.Core.Models
{
    public class RelatedTransactionsFormPost
    {

        [JsonProperty("filed_from")]
        public string FiledFrom { get; set; }

        [JsonProperty("filed_to")]
        public string FiledTo { get; set; }

        [JsonProperty("StartRange")]
        public string StartRange { get; set; }

        [JsonProperty("EndRange")]
        public string EndRange { get; set; }

        [JsonProperty("do_type")]
        public string DoType { get; set; }

        [JsonProperty("pend")]
        public string Pend { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("sort1")]
        public string Sort1 { get; set; }

        [JsonProperty("CGIPerl")]
        public string CGIPerl { get; set; }
    }
}
