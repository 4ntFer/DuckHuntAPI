using DuckHuntAPI.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Repository
{
    // <summary>
    // Class <c>ImageSeqRepository<c> class responsible for provides access ImageSeq's table registers.
    // </summary>
    public class ImageSeqRepository
    {
        private readonly ISession _session;

        public ImageSeqRepository(ISession session)
        {
            this._session = session;
        }

        public List<ImageSeq> findAll() {
            return _session.Query<ImageSeq>().ToList();
        }

        public List<ImageSeq> findById(int id)
        {
            return _session.Query<ImageSeq>().Where(imgseq=> imgseq.Id == id).ToList();
        }

        public List<ImageSeq> FindByAnimarionId(int AnimationId) {
            return this._session.Query<ImageSeq>().Where(imgseq => imgseq.AnimationId == AnimationId).OrderBy(imgseq => imgseq.ImageId).ToList();
        }

    }
}
