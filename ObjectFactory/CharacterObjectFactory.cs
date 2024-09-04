using DuckHuntAPI.ClassObjects;
using DuckHuntAPI.Models;
using DuckHuntAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ObjectFactory
{
    public class CharacterObjectFactory
    {
        private CharacterRepository characterRepository;
        private AnimationRepository animationRepository;
        private AnimationObjectFactory animationObjectFactory;

        public CharacterObjectFactory(CharacterRepository characterRepository, AnimationRepository animationRepository, AnimationObjectFactory animationObjectFactory) {
            this.characterRepository = characterRepository;
            this.animationRepository = animationRepository;
            this.animationObjectFactory = animationObjectFactory;
        }

        public List<AnimationObject> GetAnimations(int id) {
            List<AnimationObject> result = new List<AnimationObject>();
            List<Animation> animations = animationRepository.findAll();

            foreach (Animation a in animations) {
                result.Add(new AnimationObject(a, animationObjectFactory));
            }
            return result;
        }
    }
}
