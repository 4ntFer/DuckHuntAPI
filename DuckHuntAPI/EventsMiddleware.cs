using DuckHuntAPI.Security;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DuckHuntAPI
{
    // <summary>
    // Class <c>NHibernateHelper<c> Manages NHibernate's sessions objects.
    // </summary>
    public class EventsMiddleware
    {
        private readonly RequestDelegate _next;

        public EventsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            SecurityExecutor securityExecutor = null;

            // Do tasks before other middleware here, aka 'BeginRequest'
            NHibernateHelper.OpenSession(context);

            // Let the middleware pipeline run
            securityExecutor = new SecurityExecutor(
                context,
                Environment.CLIENT_ALLOWED_ACCESSES,
                Environment.CLIENT_ALLOWED_ACCESSES_RANGE,
                Environment.CLIENT_BAN_TIME);

            if(!securityExecutor.CanAccess())
                await _next(context);

            // Do tasks after middleware here, aka 'EndRequest'
            NHibernateHelper.CloseSession(context);
        }
    }
}
