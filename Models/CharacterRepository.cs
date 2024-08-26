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
    }
}
