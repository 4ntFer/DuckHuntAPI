using DuckHuntAPI.Models;
using DuckHuntAPI.Repository.Abtractions;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace DuckHuntAPI.Repository.Concrete
{
    public class CharacterRepository : ICharacterRepository
    {
        public CharacterRepository(ISession session) : base(session)
        {
        }

        public override IList<Character> FindAll()
        {
            return _session.Query<Character>().ToList();
        }

        public override Character FindById(int id)
        {
            return _session.Get<Character>(id);
        }

        public override IList<Character> FindByName(string name)
        {
            return _session.Query<Character>().Where(c => c.name == name).ToList();
        }
    }
}
