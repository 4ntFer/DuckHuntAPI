using DuckHuntAPI.ClassObjects;
using DuckHuntAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ObjectFactory
{
    //Factory nunca deve instanciar outros repositorios, pois isso segnificaria abrir varios sessões
    //Provê atributos do Objeto ImageObject
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
