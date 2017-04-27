using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers.api
{
    [AllowAnonymous]
    public class IndexController : ApiController
    { 
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }



        public string GetById(string id)
        {
            return "ID";
        }
        public string GetByName(string name)
        {
            return "NAME";
        }


        [HttpPost]
        public string K1(string value)
        {
            return value + "K1";
        }
        [HttpPost]
        public string K2(string value)
        {
            return value + "K2";
        }
        [HttpPost]
        public string K3(string value)
        {
            return value + "K3";
        }
    }
}
