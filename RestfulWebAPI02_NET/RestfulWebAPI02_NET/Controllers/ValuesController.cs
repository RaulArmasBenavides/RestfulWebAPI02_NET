using System;
using System.Net;
using System.Threading;
using System.Web.Http;

namespace RestfulWebAPI02_NET.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public ValuesController()
        {
             
        }

        // GET api/values2
        [HttpGet]
        //[Authorize(Roles ="USUARIO")]
        [Route("api/getMessage")]
        public string getMessage()
        {
            return "hola";
        }

    }
}
