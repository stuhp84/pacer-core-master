
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseFileLocationFormObject
    {


        [JsonProperty("CaseFileLocationSelectOptionValues")]
        public CaseFileLocationSelectOptionValues CaseFileLocationSelectOptionValues { get; set; }

        [JsonProperty("CaseFileLocationForm")]
        public CaseFileLocationForm CaseFileLocationForm { get; set; }

    }

}
