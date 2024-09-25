using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>ImageRepository<c> class responsible for provides access Image's table registers.
    // </summary>
    public class ImageRepository
    {
        protected readonly ISession _session;

        public ImageRepository(ISession session)
        {
            this._session = session;
        }

        public List<Image> FindAllImages() {
            return _session.Query<Image>().ToList();
        }
        

        public Image FindById(int id) {
            Image currentImage = _session.Get<Image>(id);

            return currentImage;
        }
    }
}
