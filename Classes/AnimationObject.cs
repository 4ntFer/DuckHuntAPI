using DuckHuntAPI.Models;
using DuckHuntAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Classes
{
    public class AnimationObject : Animation
    {
        private List<Image> Images; //TODO: DEFINIR GETTER
        
         public AnimationObject(Animation animation) {
            this.Id = animation.Id;
            this.Name = animation.Name;
            this.ImageSeqId = animation.ImageSeqId;
        }
        //TODO: URL
        //TODO: Remover método, adicionar getter de images
        //      Fazer LoadImages e getUrl para Images Object
        public List<string> GetImageUrlList(){
            List<string> ImgUrlList;
            List<ImageSeq> imgSeqList;

            ImgUrlList = new List<string>();
            imgSeqList = new ImageSeqRepository().findByAnimation(this.Id);

            foreach (ImageSeq imgseq in imgSeqList)
            {
                ImgUrlList.Add(Environment.SOURCE_URL + "/image/" + imgseq.ImageId);
            }

            return ImgUrlList;
        }
    }
}
