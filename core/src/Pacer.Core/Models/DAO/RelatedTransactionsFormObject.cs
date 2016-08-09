
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class RelatedTransactionsFormObject
    {


        [JsonProperty("RelatedTransactionsSelectOptionValues")]
        public RelatedTransactionsSelectOptionValues RelatedTransactionsSelectOptionValues { get; set; }

        [JsonProperty("RelatedTransactionsForm")]
        public RelatedTransactionsForm RelatedTransactionsForm { get; set; }

    }

}
