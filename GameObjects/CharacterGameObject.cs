using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ClassObjects
{
    /// <summary>
    /// Class <c>CharacterObject</c> models a database desassociated character representation.
    /// </summary>
    public class CharacterGameObject : Character
    {
        private List<AnimationGameObject> Animations;
        private CharacterGameObjectAttributesBuilder AttributesBuilder;

        //TODO: Remover construtor e fazer método que monta o objeto no factory
        public CharacterGameObject(Character character, CharacterGameObjectAttributesBuilder objectFactory) {
            this.id = character.id;
            this.name = character.name;
            this.AttributesBuilder = objectFactory;
        }

        /// <summary>
        /// Method <c>GetAnimations</c> returns animations of character. If this method is naver invoked, animations are never loaded in memory for this object.
        /// </summary>
        public List<AnimationGameObject> GetAnimations() {
            if (Animations == null)
                LoadAnimations();
            return Animations;
        }


        private void LoadAnimations() {
            Animations = AttributesBuilder.BuildAnimationsOf(this.id);
        }
    }
}
