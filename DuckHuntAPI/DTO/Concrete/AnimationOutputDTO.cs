using DuckHuntAPI.DTO.Abstractions;
using DuckHuntAPI.Models;
using System.Collections.Generic;

namespace DuckHuntAPI.DTO.Concrete
{
    public class AnimationOutputDTO : IAnimationOutputDTO
    {
        public AnimationOutputDTO(Animation animation) : base(animation)
        {
        }

        protected override IList<string> GetFramesImageLink(IList<ImageSeq> imgseq)
        {
            IList<string> result = new List<string>(imgseq.Count);
            foreach (ImageSeq i in imgseq) {
                ImageOutputDTO img = new ImageOutputDTO(i.image);
                result.Insert(i.imageIndex, img.imageLink);
            }

            return result;
        }
    }
}
