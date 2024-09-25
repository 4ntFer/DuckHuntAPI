using DuckHuntAPI.ClassObjects;
using DuckHuntAPI.Models;
using DuckHuntAPI.Repository;
using System.Collections.Generic;

namespace DuckHuntAPI.ObjectFactory
{
    // <summary>
    // Class <c>CharacterObjectFactory<c> CharacterObject's properties builder. The buid is make through the repositories.
    // </summary>
    public class CharacterGameObjectAttributesBuilder
    {
        private CharacterRepository characterRepository;
        private AnimationRepository animationRepository;
        private AnimationGameObjectAttributesBuilder animationObjectFactory;

        public CharacterGameObjectAttributesBuilder(CharacterRepository characterRepository, AnimationRepository animationRepository, AnimationGameObjectAttributesBuilder animationObjectFactory) {
            this.characterRepository = characterRepository;
            this.animationRepository = animationRepository;
            this.animationObjectFactory = animationObjectFactory;
        }

        // <summary>
        // Method <c>GetAnimation<c> Returns Character's AnimationObject by Character's id.
        // </summary>
        public List<AnimationGameObject> BuildAnimationsOf(int id) {
            List<AnimationGameObject> result = new List<AnimationGameObject>();
            List<Animation> animations = animationRepository.findByCharacter(id);

            foreach (Animation a in animations) {
                result.Add(new AnimationGameObject(a, animationObjectFactory));
            }
            return result;
        }
    }
}
