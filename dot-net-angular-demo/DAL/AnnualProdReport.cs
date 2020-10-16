using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DAL
{

    public class AnnualProdReport
    {
        public string help { get; set; }
        public bool success { get; set; }
        public Result result { get; set; }

        public static void PopulateChildrenWithId(ref AnnualProdReport theReports)
        {
            var id = theReports.result.resource_id;
            theReports.result.fields.ForEach(f => f.ResultId = id);
            theReports.result.records.ForEach(r => r.ResultId = id);
            theReports.result._links.ResultId = id;
        }

        public static void Init()
        {
            var baseUri = "https://inventory.data.gov/api/3/";
            var requestUri = "action/datastore_search?resource_id=72a33ebb-3efe-455b-9e41-0733aaed7780&limit=5";
            var theReports = APIClient.GetAnnualProdReportFromAPI(baseUri, requestUri);
            SqlUtils.InsertValuesToDB(theReports);
        }
    }

    public class Result
    {
        public string resource_id { get; set; }
        public List<Field> fields { get; set; }
        public List<Record> records { get; set; }
        public _Links _links { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class _Links
    {
        public string ResultId { get; set; }
        public string start { get; set; }
        public string next { get; set; }
    }

    public class Field
    {
        public string ResultId { get; set; }
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Record
    {
        public string ResultId { get; set; }
        public int _id { get; set; }
        [JsonProperty("$5 Bills")]
        public string _5Bills { get; set; }
        [JsonProperty("$50 Bills")]
        public string _50Bills { get; set; }
        [JsonProperty("$1 Bills")]
        public string _1Bills { get; set; }
        [JsonProperty("$10 Bills")]
        public string _10Bills { get; set; }
        [JsonProperty("$100 Bills")]
        public string _100Bills { get; set; }
        [JsonProperty("$2 Bills")]
        public string _2Bills { get; set; }
        [JsonProperty("$20 Bills")]
        public string _20Bills { get; set; }
        [JsonProperty("Fiscal Year")]
        public string FiscalYear { get; set; }
    }
}