//HistoryController

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PackageDelivery.WebServices.Controllers
{
    public class HistoryController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "history", "history2" };
        }


        public string Get(int id)
        {
            return "history";
        }


        public void Post([FromBody] string history)
        {
        }


        public void Put(int id, [FromBody] string history2)
        {
        }

        public void Delete(int id)
        {
        }
    }
}

