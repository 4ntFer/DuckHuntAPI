using DuckHuntAPI.Models;
using DuckHuntAPI.Repository.Abtractions;
using NHibernate;
using NHibernate.Util;
using System.Collections.Generic;
using System.Linq;

namespace DuckHuntAPI.Repository.Concrete
{
    public class AnimationRepository : IAnimationRepository
    {
        public AnimationRepository(ISession session) : base(session)
        {
        }

        public override IList<Animation> FindAll()
        {
            return _session.Query<Animation>().ToList();
        }

        public override Animation FindById(int id)
        {
            return _session.Get<Animation>(id);
        }

        public override IList<Animation> FindByName(string name)
        {
            IList<Animation> result = 
                _session.Query<Animation>().
                Where(a => a.name == name).ToList();

            if(result.Count  == 0)
                return null;

            return result;
        }

        public override IList<Animation> OfCharacter(int characterId)
        {
            IList<Animation> result = 
                _session.Query<Animation>().
                Where(a => a.characterId == characterId).ToList();

            return result;
        }
    }
}
