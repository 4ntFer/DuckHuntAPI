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
        private List<ImageObject> Images; //TODO: DEFINIR GETTER
        private AnimationObjectFactory Factory;
        
         public AnimationObject(Animation animation, AnimationObjectFactory Factory) {
            this.Id = animation.Id;
            this.Name = animation.Name;
            this.ImageSeqId = animation.ImageSeqId;
            this.Factory = Factory;
        }
        //TODO: URL
        //TODO: adicionar getter de images
        //      Fazer LoadImages e getUrl para Images Object

        public List<ImageObject> GetImages() {
            if (Images == null) {
                LoadImageObjects();
            }

            return Images;
        }

        private List<ImageObject> LoadImageObjects() {
            Images = Factory.GetImagesOf(this.Id);
            return Images;
        }
    }
}
