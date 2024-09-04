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
    public class CharacterObject : Character
    {
        private List<AnimationObject> Animations;
        private CharacterObjectFactory ObjectFactory;

        public CharacterObject(Character character, CharacterObjectFactory objectFactory) {
            this.id = character.id;
            this.name = character.name;
            this.ObjectFactory = objectFactory;
        }

        /// <summary>
        /// Method <c>GetAnimations</c> returns animations of character. If this method is naver invoked, animations are never loaded in memory for this object.
        /// </summary>
        public List<AnimationObject> GetAnimations() {
            if (Animations == null)
                LoadAnimations();
            return Animations;
        }


        private void LoadAnimations() {
            Animations = ObjectFactory.GetAnimations(this.id);
        }
    }
}
