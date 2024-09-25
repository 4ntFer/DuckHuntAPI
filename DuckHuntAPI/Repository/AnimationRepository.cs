using DuckHuntAPI.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DuckHuntAPI.Repository
{
    // <summary>
    // Class <c>AnimationRepository<c> class responsible for provides access Animation's table registers.
    // </summary>
    public class AnimationRepository
    {
        protected readonly ISession _session;

        public AnimationRepository(ISession session)
        {
            this._session = session;
        }

        public List<Animation> findByCharacter(int characterId) {
            return _session.Query<Animation>().Where(a => a.CharacterId == characterId).ToList();
        }

        public List<Animation> findAll()
        {
            return _session.Query<Animation>().ToList();
        }

        public Animation findByName(string AnimationName) {

            try
            {
                return _session.Query<Animation>().Where(a => a.Name.ToLower() == AnimationName.ToLower()).First();
            }
            catch {
                return null;
            }
        }
    }
}
