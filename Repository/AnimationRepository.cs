using DuckHuntAPI.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DuckHuntAPI.Repository
{
    public class AnimationRepository
    {
        private readonly ISession _session;

        public AnimationRepository() {
            _session = NHibernateHelper.GetSessionFactory().OpenSession();
        }

        public List<Animation> findByCharacter(int characterId) {
            return _session.Query<Animation>().Where(a => a.CharacterId == characterId).ToList();
        }

        public List<Animation> findAll()
        {
            return _session.Query<Animation>().ToList();
        }
    }
}
