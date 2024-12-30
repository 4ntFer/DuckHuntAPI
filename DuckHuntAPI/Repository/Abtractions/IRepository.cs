using NHibernate;
using System.Collections;
using System.Collections.Generic;

namespace DuckHuntAPI.Repository.Abtractions
{
    public abstract class IRepository<T>
    {
        protected readonly ISession _session;

        public IRepository(ISession session) {
            _session = session;
        }

        public abstract IList<T> FindAll();
        public abstract T FindById(int id);
    }
}
