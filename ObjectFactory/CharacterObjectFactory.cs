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
        private CharacterRepository CharacterRepos;
        private AnimationRepository AnimationRepos;
        private AnimationObjectFactory AnimationFactory;

        

        public List<AnimationObject> GetAnimations(int id) {
            List<AnimationObject> result = new List<AnimationObject>();
            List<Animation> animations = AnimationRepos.findAll();

            foreach (Animation a in animations) {
                result.Add(new AnimationObject(a, AnimationFactory));
            }
            return result;
        }
    }
}
