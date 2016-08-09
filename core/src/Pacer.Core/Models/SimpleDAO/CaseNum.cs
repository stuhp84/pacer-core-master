using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacer.Core.Models.SimpleDAO
{
    public class CaseNum
    {
        [JsonProperty("caseNum")]
        public string caseNum { get; set; }
    }
}
