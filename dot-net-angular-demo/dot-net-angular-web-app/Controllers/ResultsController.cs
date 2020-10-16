using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        public Result[] Get()
        {
            var results = SqlUtils.GetResults();
            results[0].fields = SqlUtils.GetFields(results[0].resource_id);
            results[0].records = SqlUtils.GetRecords(results[0].resource_id).OrderBy(r => r._id).ToList();
            results[0]._links = SqlUtils.GetLinks(results[0].resource_id);
            
            return results;
        }
    }
}