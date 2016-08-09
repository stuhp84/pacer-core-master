using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pacer.Core.Models
{
    public class CaseFileLocationFormPost
    {
        [JsonProperty("CaseidVols")]
        public string CaseidVols { get; set; }

        [JsonProperty("SelectAll")]
        public string SelectAll { get; set; }

        [JsonProperty("CGIPerl")]
        public string CGIPerl { get; set; }
    }
}
