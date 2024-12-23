using DuckHuntAPI.DTO.Abstractions;
using DuckHuntAPI.Models;
using NHibernate.Mapping;
using System.Collections.Generic;
using System.ComponentModel;
using System.Transactions;

namespace DuckHuntAPI.DTO.Concrete
{
    public class CharacterOutputDTO : ICharacterOutputDTO
    {
        public CharacterOutputDTO(Character character) : base(character){}

        protected override IList<IDictionary<object, object>> GetDTOAnimations(IList<Animation> animations)
        { 
            IList<IDictionary<object, object>> result = new List<IDictionary<object,object>>();
            foreach (Animation a in animations) {
                AnimationOutputDTO animationDTO = new AnimationOutputDTO(a);
                IDictionary<object,object> animationDictionary = new Dictionary<object, object>();
                animationDictionary.Add("name", a.name);
                animationDictionary.Add("framesImageLink", animationDTO.framesImageLink);
                result.Add(animationDictionary);
            }
            return result;
        }

        protected override IList<IDictionary<object, object>> GetDTOImages(IList<Image> images)
        {
            IList<IDictionary<object, object>> result = new List<IDictionary<object, object>>();
            foreach (Image img in images) {
                ImageOutputDTO imageDTO = new ImageOutputDTO(img);
                IDictionary<object,object> imgDictionary = new Dictionary<object, object>();
                imgDictionary.Add("id", imageDTO.id);
                imgDictionary.Add("ImageLink", imageDTO.imageLink);
                result.Add(imgDictionary);
            }
            return result;
        }
    }
}
