
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class Billing
    {

        [JsonProperty("PacerCenter")]
        public string PacerCenter { get; set; }

        [JsonProperty("TransactionReceipt")]
        public string TransactionReceipt { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Time")]
        public string Time { get; set; }

        [JsonProperty("PacerLogin")]
        public string PacerLogin { get; set; }

        [JsonProperty("ClientCode")]
        public string ClientCode { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("SearchCriteria")]
        public string SearchCriteria { get; set; }

        [JsonProperty("BillablePages")]
        public string BillablePages { get; set; }

        [JsonProperty("Cost")]
        public string Cost { get; set; }
    }

}
