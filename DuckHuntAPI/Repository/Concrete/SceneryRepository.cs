using DuckHuntAPI.Models;
using DuckHuntAPI.Repository.Abtractions;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace DuckHuntAPI.Repository.Concrete
{
    public class SceneryRepository : ISceneryRepository
    {
        public SceneryRepository(ISession session) : base(session)
        {
        }

        public override IList<Scenery> FindAll()
        {
            return _session.Query<Scenery>().ToList();
        }

        public override Scenery FindById(int id)
        {
            return _session.Get<Scenery>(id);
        }

        public override IList<Scenery> FindByName(string name)
        {
            return _session.Query<Scenery>().Where(s => s.name == name).ToList();
        }

        public override IList<Scenery> FindByType(string type)
        {
            return _session.Query<Scenery>().Where(s => s.type == type).ToList();
        }
    }
}
