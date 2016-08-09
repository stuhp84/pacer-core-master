
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class MainFormObject
    {


        [JsonProperty("MainFormSelectOptionValues")]
        public MainFormSelectOptionValues MainFormSelectOptionValues { get; set; }

        [JsonProperty("MainFormForm")]
        public MainFormForm MainFormForm { get; set; }

    }

}
