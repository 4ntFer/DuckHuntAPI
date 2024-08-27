using DuckHuntAPI.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Repository
{
    public class ImageSeqRepository
    {
        private readonly ISession _session;

        public ImageSeqRepository() {
            _session = NHibernateHelper.GetSessionFactory().OpenSession();
        }

        public List<ImageSeq> findAll() {
            return _session.Query<ImageSeq>().ToList();
        }

        public List<ImageSeq> findById(int id)
        {
            return _session.Query<ImageSeq>().Where(imgseq=> imgseq.Id == id).ToList();
        }

        public List<ImageSeq> findByAnimation(int id)
        {
            return _session.Query<ImageSeq>().ToList()/*.Where(imgseq => imgseq.AnimationId == id).OrderBy(imgseq => imgseq.ImageId).ToList() */;
        }
    }
}
