
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class HistoryDocumentsFormObject
    {


        [JsonProperty("HistoryDocumentsSelectOptionValues")]
        public HistoryDocumentsSelectOptionValues HistoryDocumentsSelectOptionValues { get; set; }

        [JsonProperty("HistoryDocumentsForm")]
        public HistoryDocumentsForm HistoryDocumentsForm { get; set; }

    }

}
