using DuckHuntAPI.Classes;
using DuckHuntAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Repository
{
    //Factory nunca deve instanciar outros repositorios, pois isso segnificaria abrir varios sessões
    // Provê atributos do objetos AnimationObject
    public class AnimationObjectFactory : AnimationRepository
    {

        public List<ImageObject> GetImagesOf(int AnimationId) {
            List<ImageObject> ImgObjList;
            List<ImageSeq> imgSeqList;

            ImgObjList = new List<ImageObject>();
            imgSeqList = this._session.Query<ImageSeq>().Where(imgseq => imgseq.AnimationId == AnimationId).OrderBy(imgseq => imgseq.ImageId).ToList();

            foreach (ImageSeq imgseq in imgSeqList)
            {
                ImgObjList.Add(new ImageObject(_session.Get<Image>(imgseq.Id)));
            }

            return ImgObjList;
        }
    }

}
