using DuckHuntAPI.Models;
using NHibernate;

namespace DuckHuntAPI.Repository.Abtractions
{
    public abstract class ICharacterRepository : IRepository<Character>
    {
        public ICharacterRepository(ISession session) : base(session)
        {
        }

        public abstract Character FindByName(string name);
    }
}
