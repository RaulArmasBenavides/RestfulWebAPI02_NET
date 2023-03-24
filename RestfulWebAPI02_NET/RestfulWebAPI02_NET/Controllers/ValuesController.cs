using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace RestfulWebAPI02_NET.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        // GET api/values2
        public JsonResult Get()
        {
            var result = new JsonResult();
            result.Data = new
            {
                id = 2
            };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        //// POST api/values
        public JsonResult ExampleJSON()
        {
            var result = new JsonResult();
            result.Data = new
            {
                id = 1
            };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
