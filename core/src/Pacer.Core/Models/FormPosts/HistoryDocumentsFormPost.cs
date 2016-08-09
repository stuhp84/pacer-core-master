using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pacer.Core.Models
{
    public class HistoryDocumentsFormPost
    {
        [JsonProperty("QueryType")]
        public string QueryType { get; set; }

        [JsonProperty("DisplayDktText")]
        public string DisplayDktText { get; set; }

        [JsonProperty("sort1")]
        public string Sort1 { get; set; }

        [JsonProperty("CGIPerl")]
        public string CGIPerl { get; set; }
    }
}
