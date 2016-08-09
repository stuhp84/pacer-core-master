
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class DocketTable
    {

        [JsonProperty("DateFiled")]
        public string DateFiled { get; set; }

        [JsonProperty("hash")]
        public object Hash { get; set; }

        [JsonProperty("DocketText")]
        public string DocketText { get; set; }
    }

}
