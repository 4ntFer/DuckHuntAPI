using DuckHuntAPI.Classes;
using DuckHuntAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Repository.ObjectFactory
{
    //Factory nunca deve instanciar outros repositorios, pois isso segnificaria abrir varios sessões
    //Provê atributos do Objeto ImageObject
    public class ImageObjectFactory : ImageRepository
    {
        public ImageObject GetImageObject(int id) {
            //TODO: montar objeto
            return new ImageObject(FindById(id));
        }
    }
}
