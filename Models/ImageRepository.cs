using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    public class ImageRepository
    {
        private readonly ISession session;

        public ImageRepository() {
            session = NHibernateHelper.GetSessionFactory().OpenSession();
        }

        public Image FindById(int id) {
            Image currentImage = session.Get<Image>(id);

            return currentImage;
        }
    }
}
