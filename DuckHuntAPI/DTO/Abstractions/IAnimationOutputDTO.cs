using DuckHuntAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace DuckHuntAPI.DTO.Abstractions
{
    public abstract class IAnimationOutputDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<string> framesImageLink { get; set; }

        public IAnimationOutputDTO(Animation animation) {
            id = animation.Id;
            name = animation.name;
            framesImageLink = GetFramesImageLink(animation.imageSequence);
        }

        protected abstract IList<string> GetFramesImageLink(IList<ImageSeq> imgseq);
    }
}
