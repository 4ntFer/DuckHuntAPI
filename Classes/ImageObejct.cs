using DuckHuntAPI.Models;
using DuckHuntAPI.Repository.ObjectFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Classes
{
    public class ImageObject : Image
    {
        public string url { get; set; }
        private ImageObjectFactory Repository;

        public ImageObject(Image image) {
            this.id = image.id;
            this.data = image.data;
            this.url = Environment.SOURCE_URL + "/image/" + this.id;
        }
    }
}
