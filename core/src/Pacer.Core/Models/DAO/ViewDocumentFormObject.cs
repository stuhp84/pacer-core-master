
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class ViewDocumentFormObject
    {


        [JsonProperty("ViewDocumentSelectOptionValues")]
        public ViewDocumentSelectOptionValues ViewDocumentSelectOptionValues { get; set; }

        [JsonProperty("ViewDocumentForm")]
        public ViewDocumentForm ViewDocumentForm { get; set; }

    }

}
