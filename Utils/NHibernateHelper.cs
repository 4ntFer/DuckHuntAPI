using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISession = NHibernate.ISession;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace DuckHuntAPI
{
    // <summary>
    // Class <c>NHibernateHelper<c> Responsible for provides NHibernate's sessions objects.
    // </summary>
    public class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private const string SESSION_KEY = "MPS.NHibernate.SESSION_KEY";
        private static ISessionFactory _sessionFactory = null;

        public static ISessionFactory GetSessionFactory() {
            if (_sessionFactory == null) {
                _sessionFactory = new Configuration().Configure().BuildSessionFactory();
            }

            return _sessionFactory;
        }

        // <summary>
        // Method <c>OpenSession<c> Open session and associetes with HTTP context.
        // </summary>
        public static void OpenSession(HttpContext context) {
            ISession session = NHibernateHelper.GetSessionFactory().OpenSession();
            SetSession(session, context);
        }

        // <summary>
        // Method <c>CloseSession<c> Close session and desassocietes from HTTP context.
        // </summary>
        public static void CloseSession(HttpContext context) {
            ISession session = NHibernateHelper.GetSession(context);
            SetSession(null, context);
            session.Close();
        }

        // <summary>
        // Method <c>GetSession<c> Returns session from HTTP context.
        // </summary>
        public static ISession GetSession(HttpContext context) {

            return (ISession)context.Items[SESSION_KEY];
        }

        // <summary>
        // Method <c>SetSession<c> Associates session with HTTP context.
        // </summary>
        private static void SetSession(ISession session, HttpContext context) {
            if (session != null)
            {
                context.Items[SESSION_KEY] = session;
            }
            else {
                context.Items.Remove(SESSION_KEY);
            }
        }
    }
}
