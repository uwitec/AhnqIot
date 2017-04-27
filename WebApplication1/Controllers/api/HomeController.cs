using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebApplication1.Controllers.api
{
    [AllowAnonymous]
    public class HomeController : ApiController
    {
        private User[] Users = new User[]
        {
            new User() { uid = "a",pwd="aa"},
            new User() { uid = "b",pwd="bb"},
            new User() { uid = "c",pwd="cc"},
            new User() { uid = "d",pwd="dd"},
            new User() { uid = "e",pwd="ee"},
        };

        public string GetAllUser()
        {
            return JsonConvert.SerializeObject(Users);
        }

        public string GetByUid(string uid)
        {
            return JsonConvert.SerializeObject(Users.FirstOrDefault(e => e.uid.Equals(uid)));
        }

        //public string GetByUAP(string uid, string pwd)
        //{
        //    return JsonConvert.SerializeObject(Users.FirstOrDefault(e => e.uid.Equals(uid) && e.pwd.Equals(pwd)));
        //}

        public string GetByUAP([FromUri]User u)
        {
            return JsonConvert.SerializeObject(Users.FirstOrDefault(e => e.uid.Equals(u.uid) && e.pwd.Equals(u.pwd)));
        }

        [Route("api/v1/home/getbyuap2/{uid}/{pwd}")]
        public string GetByUAP2([FromUri]User u)
        {
            return JsonConvert.SerializeObject(Users.FirstOrDefault(e => e.uid.Equals(u.uid) && e.pwd.Equals(u.pwd)));
        }
    }

    public class User
    {
        public string uid { get; set; }

        public string pwd { get; set; }
    }
}
