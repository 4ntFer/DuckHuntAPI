using DuckHuntAPI.Models;
using NHibernate;
using System.Collections.Generic;

namespace DuckHuntAPI.Repository.Abtractions
{
    public abstract class ICharacterRepository : IRepository<Character>
    {
        public ICharacterRepository(ISession session) : base(session)
        {
        }

        public abstract IList<Character> FindByName(string name);
    }
}
