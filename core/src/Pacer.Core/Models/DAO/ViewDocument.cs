
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class ViewDocument
    {

        [JsonProperty("DocumentNumber")]
        public string DocumentNumber { get; set; }

        [JsonProperty("DocumentURL")]
        public string DocumentURL { get; set; }

        [JsonProperty("TotalPages")]
        public string TotalPages { get; set; }

        [JsonProperty("TotalSize")]
        public string TotalSize { get; set; }

        [JsonProperty("AttachmentTotalPages")]
        public string AttachmentTotalPages { get; set; }

        [JsonProperty("AttachmentTotalSize")]
        public string AttachmentTotalSize { get; set; }

        [JsonProperty("queryResult")]
        public QueryResultLong[] QueryResult { get; set; }


    }

}
