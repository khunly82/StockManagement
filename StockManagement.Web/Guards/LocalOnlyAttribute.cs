using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.Claims;

namespace StockManagement.Web.Guards
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class LocalOnlyAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            IPAddress? remoteIp = context.HttpContext.Connection.RemoteIpAddress;
            context.HttpContext.User.AddIdentity(new ClaimsIdentity([
                    new Claim(ClaimTypes.Role, "Server")
            ], "Basic"));

            if (remoteIp == null || !IPAddress.IsLoopback(remoteIp))
            {
                context.Result = new StatusCodeResult(403); // Interdit
            }
        }
    }
}
