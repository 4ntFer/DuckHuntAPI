using DuckHuntAPI.ClassObjects;
using DuckHuntAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ObjectFactory
{
    // <summary>
    // Class <c>AnimationObjectFactory<c> CharacterAnimation's properties builder. The buid is make through the repositories.
    // </summary>
    public class ImageObjectFactory
    {
        private ImageRepository ImgRepos;

        public ImageObjectFactory(ImageRepository ImgRepository) {
            ImgRepos = ImgRepository;
        }
        public ImageObject GetImageObject(int id) {
            //TODO: montar objeto
            return new ImageObject(ImgRepos.FindById(id));
        }
    }
}
