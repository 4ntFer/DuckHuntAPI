using DuckHuntAPI.Models;
using System.Collections.Generic;

namespace DuckHuntAPI.DTO.Abstractions
{
    public abstract class ICharacterOutputDTO
    {
        public int id { set; get; }
        public string name { set; get; }
        public IList<IDictionary<object, object>> images { set; get; }
        public IList<IDictionary<object, object>> animations { set; get; }

        public ICharacterOutputDTO(Character character)
        {
            id = character.id;
            name = character.name;
            images = GetDTOImages(character.characterImages);
            animations = GetDTOAnimations(character.animations);
        }
        protected abstract IList<IDictionary<object, object>> GetDTOImages(IList<CharacterImage> images);
        protected abstract IList<IDictionary<object, object>> GetDTOAnimations(IList<Animation> animations);
    }
}
