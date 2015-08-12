using Communicator.Services;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace Communicator.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly UserService svc;

        public UsersController()
        {
            svc = new UserService();
        }

        [Route("me")]
        public IHttpActionResult GetCurrentUser()
        {
            var current = svc.GetCurrent();
            return Ok(current);
        }
    }
}
