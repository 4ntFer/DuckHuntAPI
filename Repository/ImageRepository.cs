﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    public class ImageRepository
    {
        protected readonly ISession _session;

        public ImageRepository() {
            _session = NHibernateHelper.GetSessionFactory().OpenSession();
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
