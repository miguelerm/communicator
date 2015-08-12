using Communicator.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Communicator.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public async override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            await base.OnAuthorizationAsync(actionContext, cancellationToken);

            try
            {
                var svc = new UserService();
                await svc.CreateCurrentUserIfNotExistsAsync();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Error: {0}" + Environment.NewLine + "{1}", ex.Message, ex.ToString());
                HandleUnauthorizedRequest(actionContext);
            }
            
        }
    }
}