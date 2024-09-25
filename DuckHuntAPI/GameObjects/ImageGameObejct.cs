using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ClassObjects
{
    /// <summary>
    /// Class <c>ImageObject</c> models a database desassociated image representation.
    /// </summary>
    public class ImageGameObject : Image
    {
        public string url { get; set; }

        //TODO: Remover construtor e fazer método que monta o objeto no factory
        public ImageGameObject(Image image) {
            this.id = image.id;
            this.data = image.data;
            this.url = Environment.SOURCE_URL + "/image/" + this.id;
        }
    }
}
