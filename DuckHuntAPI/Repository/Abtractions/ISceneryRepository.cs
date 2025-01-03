using DuckHuntAPI.Models;
using NHibernate;
using Remotion.Linq.Clauses.ExpressionVisitors;
using System.Collections.Generic;
using System.Linq;

namespace DuckHuntAPI.Repository.Abtractions
{
    public abstract class ISceneryRepository : IRepository<Scenery>
    {
        protected ISceneryRepository(ISession session) : base(session)
        {
        }

        public abstract IList<Scenery> FindByName(string name);

        public abstract IList<Scenery> FindByType(string type);
    }
}
