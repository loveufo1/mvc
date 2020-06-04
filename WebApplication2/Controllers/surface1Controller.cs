using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class surface1Controller : ApiController
    {
        // GET: api/surface1
        public IEnumerable<customer> Get()
        {
            customer[] c = new customerfactory().getall();
            foreach(customer cc in c)
            {
                cc.password = "***";
                cc.phone = cc.phone.Substring(0, 3) + "***";
                
            }
            return c;
            //return customerfactory().getall();
        }

        // GET: api/surface1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/surface1
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/surface1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/surface1/5
        public void Delete(int id)
        {
        }
    }
}
