using DuckHuntAPI.DTO.Abstractions;
using DuckHuntAPI.Models;
using System.Collections.Generic;
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
                IDictionary<object,object> animationDictionary = new Dictionary<object, object>();
                IList<string> imagesLink = new List<string>(a.imageSequence.Count);
                foreach (ImageSeq i in a.imageSequence) {
                    //TODO atribuir um link por imagem
                    // O que está implementado representa um teste
                    imagesLink.Insert(i.imageIndex, "URL:/" + i.image.id);
                }
                animationDictionary.Add("name", a.name);
                animationDictionary.Add("images", imagesLink);
                result.Add(animationDictionary);
            }
            return result;
        }

        protected override IList<IDictionary<object, object>> GetDTOImages(IList<Image> images)
        {
            IList<IDictionary<object, object>> result = new List<IDictionary<object, object>>();
            foreach (Image img in images) {
                //TODO atribuir um link por imagem
                // O que está implementado representa um teste
                IDictionary<object,object> imgDictionary = new Dictionary<object, object>();
                imgDictionary.Add("id", img.id);
                imgDictionary.Add("ImageLink", "URL:/" + img.id);
            }
            return result;
        }
    }
}
