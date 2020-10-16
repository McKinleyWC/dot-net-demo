using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    [TestClass()]
    public class SqlUtilsTests
    {
        [TestMethod()]
        public void GetResultsTest()
        {
            var results = SqlUtils.GetResults();
            Assert.IsNotNull(results);
        }

        [TestMethod()]
        public void GetResultsTest1()
        {
            var results = SqlUtils.GetResults("72a33ebb-3efe-455b-9e41-0733aaed7780");
            Assert.IsNotNull(results);
        }

        [TestMethod()]
        public void GetFieldsTest()
        {
            var results = SqlUtils.GetFields("72a33ebb-3efe-455b-9e41-0733aaed7780");
            Assert.IsNotNull(results);
        }

        [TestMethod()]
        public void GetFieldsTest1()
        {
            var results = SqlUtils.GetFields("72a33ebb-3efe-455b-9e41-0733aaed7780", "_id");
            Assert.IsNotNull(results);
        }

        [TestMethod()]
        public void GetRecordsTest()
        {
            var results = SqlUtils.GetRecords("72a33ebb-3efe-455b-9e41-0733aaed7780");
            Assert.IsNotNull(results);
        }

        [TestMethod()]
        public void GetRecordsTest1()
        {
            var results = SqlUtils.GetRecords("72a33ebb-3efe-455b-9e41-0733aaed7780", "1");
            Assert.IsNotNull(results);
        }

        [TestMethod()]
        public void GetLinksTest()
        {
            var results = SqlUtils.GetLinks("72a33ebb-3efe-455b-9e41-0733aaed7780");
            Assert.IsNotNull(results);
        }
    }
}