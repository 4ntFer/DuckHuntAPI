using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using DuckHuntAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ClassObjects { 
    public class AnimationObject : Animation
    {   
        private List<ImageObject> Images; 
        private AnimationObjectFactory ObjectFactory;
        
         public AnimationObject(Animation animation, AnimationObjectFactory Factory) {
            this.Id = animation.Id;
            this.Name = animation.Name;
            this.ImageSeqId = animation.ImageSeqId;
            this.ObjectFactory = Factory;
        }

        public List<ImageObject> GetImages() {
            if (Images == null) {
                LoadImageObjects();
            }

            return Images;
        }

        private void LoadImageObjects() {
            Images = ObjectFactory.GetImagesOf(this.Id);
        }
    }
}
