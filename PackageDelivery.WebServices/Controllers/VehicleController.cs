//VehicleController

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PackageDelivery.WebServices.Controllers
{
    public class VehicleController : ApiController
    {

        public IEnumerable<string> Get()
        {
            return new string[] {"placa"};
        }

        public string Get(int id)
        {
            return "placa";
        }

        public void Put(int id, [FromBody] string placa)
        {
        }


        public void Delete(int id)
        {
        }
    }
}

