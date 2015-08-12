using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Communicator.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {

        [Route("me")]
        public IHttpActionResult GetCurrentUser()
        {
            return Ok(new { Username = User.Identity.Name });
        }

    }
}
