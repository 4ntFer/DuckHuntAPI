using DuckHuntAPI.Models;
using NHibernate;
using System.Collections.Generic;

namespace DuckHuntAPI.Repository.Abtractions
{
    public abstract class IAnimationRepository : IRepository<Animation>
    {
        public IAnimationRepository(ISession session) : base(session)
        {
        }

        public abstract IList<Animation> OfCharacter(int characterId);
        public abstract IList<Animation> FindByName(string name);
    }
}
