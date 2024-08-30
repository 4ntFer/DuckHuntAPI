using Microsoft.AspNetCore.Http;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI
{
    public class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static ISessionFactory _sessionFactory = null;

        public static ISessionFactory GetSessionFactory() {
            if (_sessionFactory == null) {
                _sessionFactory = new Configuration().Configure().BuildSessionFactory();
            }

            return _sessionFactory;
        }
    }
}
