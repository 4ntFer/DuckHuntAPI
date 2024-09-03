using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using DuckHuntAPI.ObjectFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ClassObjects
{
    public class ImageObject : Image
    {
        public string url { get; set; }

        public ImageObject(Image image) {
            this.id = image.id;
            this.data = image.data;
            this.url = Environment.SOURCE_URL + "/image/" + this.id;
        }
    }
}
