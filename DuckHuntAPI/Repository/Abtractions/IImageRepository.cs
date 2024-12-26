using DuckHuntAPI.Models;
using NHibernate;
using System.Collections;
using System.Collections.Generic;

namespace DuckHuntAPI.Repository.Abtractions
{
    public abstract class IImageRepository : IRepository<Image>
    {
        public IImageRepository(ISession session) : base(session)
        {
        }

        public abstract IList<Image> OfAnimation(int AnimationId);
        public abstract IList<Image> OfCharacter(int CharacterId);
    }
}
