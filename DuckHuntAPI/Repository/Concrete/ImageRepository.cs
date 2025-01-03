using DuckHuntAPI.Models;
using DuckHuntAPI.Repository.Abtractions;
using NHibernate;
using NHibernate.Linq.Functions;
using NHibernate.SqlCommand;
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
            Image img = null;
            CharacterImage characterImage = null;
            return _session.QueryOver<Image>(() => img)
                .JoinEntityAlias(
                    () => characterImage,
                    () => img.id == characterImage.id,
                    JoinType.InnerJoin
                )
                .Where(() => characterImage.character.id == CharacterId)
                .List();
        }
    }
}
