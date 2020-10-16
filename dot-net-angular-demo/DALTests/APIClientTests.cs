using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class APIClientTests
    {
        [TestMethod()]
        public void GetAnnualProdReportFromAPITest()
        {
            var baseUri = "https://inventory.data.gov/api/3/";
            var requestUri = "action/datastore_search?resource_id=72a33ebb-3efe-455b-9e41-0733aaed7780";
            var theReports = APIClient.GetAnnualProdReportFromAPI(baseUri, requestUri);
            Assert.IsNotNull(theReports);
        }
    }
}