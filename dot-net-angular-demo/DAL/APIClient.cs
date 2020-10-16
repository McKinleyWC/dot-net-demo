using System;
using System.Collections.Generic;
using System.Net.Http;

namespace DAL
{
    public class APIClient
    {
        public static AnnualProdReport GetAnnualProdReportFromAPI(string baseUri, string requestUri)
        {
            var theReport = new AnnualProdReport();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                //HTTP GET
                var responseTask = client.GetAsync(requestUri);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<AnnualProdReport>();
                    readTask.Wait();

                    theReport = readTask.Result;
                    AnnualProdReport.PopulateChildrenWithId(ref theReport);
                }
            }
            return theReport;
        }
    }
}
