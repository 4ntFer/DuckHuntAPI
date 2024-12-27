using DuckHuntAPI.Models;
using DuckHuntAPI.Repository.Abtractions;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace DuckHuntAPI.Repository.Concrete
{
    public class ImageRepository : IImageRepository
    {
        public ImageRepository(ISession session) : base(session)
        {
        }

        public override IList<Image> FindAll()
        {
            return _session.Query<Image>().ToList();
        }

        public override Image FindById(int id)
        {
            return _session.Get<Image>(id);
        }

        public override IList<Image> OfAnimation(int AnimationId)
        {
            IList<Image> result = new List<Image>();
            IList<ImageSeq> imgSeqList =
                _session.Query<ImageSeq>().
                Where(imgSeq => imgSeq.animationId == AnimationId).
                OrderBy(imgSeq => imgSeq.imageIndex).ToList();

            foreach (var imgSeq in imgSeqList) {
                result.Add(imgSeq.image);
            }

            return result;
        }

        public override IList<Image> OfCharacter(int CharacterId)
        {
            return _session.Query<Image>().
                Where(img => img.character.id == CharacterId).ToList();
        }
    }
}
