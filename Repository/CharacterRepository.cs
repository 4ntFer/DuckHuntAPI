using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ISession session;
        public CharacterRepository() {
            session = NHibernateHelper.GetSessionFactory().OpenSession();
        }
        public Character FindById(int id)
        {
            return session.Get<Character>(id);    
        }

        public Character FindByName(string name) {
            List<Character> Characterlist = session.Query<Character>().Where(c => c.name == name).ToList();
            if (Characterlist.Count != 0)
                return Characterlist.ElementAt(0);
            return null;
        }
    }
}
