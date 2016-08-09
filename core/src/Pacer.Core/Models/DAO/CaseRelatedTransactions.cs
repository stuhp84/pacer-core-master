
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USCourts.AO.Epa.Pacer
{

    public class CaseRelatedTransactions
    {

        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("transactionTables")]
        public TransactionTable[][] TransactionTables { get; set; }


    }

}
