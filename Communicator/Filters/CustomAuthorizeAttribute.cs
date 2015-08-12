using Communicator.Services;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;

namespace Communicator.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public async override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            await base.OnAuthorizationAsync(actionContext, cancellationToken);

            try
            {
                var users = GetUserService(actionContext);
                await users.CreateCurrentUserIfNotExistsAsync();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Error: {0}" + Environment.NewLine + "{1}", ex.Message, ex.ToString());
                HandleUnauthorizedRequest(actionContext);
            }
            
        }

        private UserService GetUserService(HttpActionContext actionContext)
        {
            var requestScope = actionContext.Request.GetDependencyScope();
            return requestScope.GetService(typeof(UserService)) as UserService;
        }

    }
}