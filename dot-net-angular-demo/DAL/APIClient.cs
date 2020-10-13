using System;
using System.Collections.Generic;
using System.Net.Http;

namespace DAL
{
    public class APIClient
    {
        public static List<AnnualProdReport> GetAnnualProdReportFromAPI(string baseUri, string requestUri)
        {
            var theReports = new List<AnnualProdReport>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://inventory.data.gov/api/3/");
                //HTTP GET
                var responseTask = client.GetAsync("action/datastore_search?resource_id=72a33ebb-3efe-455b-9e41-0733aaed7780");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<AnnualProdReport>>();
                    readTask.Wait();

                    theReports = readTask.Result;
                }
            }
            return theReports;
        }
    }
}
