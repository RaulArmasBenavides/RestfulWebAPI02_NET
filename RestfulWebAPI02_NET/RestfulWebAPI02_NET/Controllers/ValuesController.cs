using System;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace RestfulWebAPI02_NET.Controllers
{
    public class ValuesController : ApiController
    {
 
        public ValuesController()
        {
        }

        [HttpGet]
        [Route("api/CheckProtocol")]
        public IHttpActionResult CheckProtocol()
        {
            string protocolVersion = HttpContext.Current.Request.ServerVariables["SERVER_PROTOCOL"];
            return Ok(protocolVersion);
        }

        // GET api/values2
        [HttpGet]
        [Authorize(Roles ="USUARIO")]
        [Route("api/getMessage")]
        public string getMessage()
        {
            return "hola";
        }

    }
}
