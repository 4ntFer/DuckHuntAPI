using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI
{
    public class EventsMiddleware
    {
        private readonly RequestDelegate _next;

        public EventsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do tasks before other middleware here, aka 'BeginRequest'
            NHibernateHelper.OpenSession(context);
            // Let the middleware pipeline run
            await _next(context);
            // Do tasks after middleware here, aka 'EndRequest'
            NHibernateHelper.CloseSession(context);
        }
    }
}
