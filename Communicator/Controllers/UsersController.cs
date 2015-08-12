using Communicator.Services;
using System.Web.Http;

namespace Communicator.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly UserService users;

        public UsersController(UserService userService)
        {
            users = userService;
        }

        [Route("me")]
        public IHttpActionResult GetCurrentUser()
        {
            var current = users.GetCurrent();
            return Ok(current);
        }
    }
}
