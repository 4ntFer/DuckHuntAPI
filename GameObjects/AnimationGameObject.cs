using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using DuckHuntAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ClassObjects {
    /// <summary>
    /// Class <c>AnimationObject</c> models a database desassociated animation representation.
    /// </summary>
    public class AnimationGameObject : Animation
    {   
        private List<ImageGameObject> Images; 
        private AnimationGameObjectAttributesBuilder AttributesBuilder;
        
        //TODO: Remover construtor e fazer método que monta o objeto no factory
         public AnimationGameObject(Animation animation, AnimationGameObjectAttributesBuilder Factory) {
            this.Id = animation.Id;
            this.Name = animation.Name;
            this.ImageSeqId = animation.ImageSeqId;
            this.AttributesBuilder = Factory;
         }

        /// <summary>
        /// Method <c>GetImages</c> returns images of animations. If this method is naver invoked, images are never loaded in memory for this object.
        /// </summary>
        public List<ImageGameObject> GetImages() {
            if (Images == null) {
                LoadImageObjects();
            }

            return Images;
        }

        private void LoadImageObjects() {
            Images = AttributesBuilder.BuildImagesOf(this.Id);
        }
    }
}
