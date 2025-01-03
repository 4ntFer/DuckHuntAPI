using DuckHuntAPI.DTO.Abstractions;
using DuckHuntAPI.Models;
using System.Collections.Generic;

namespace DuckHuntAPI.DTO.Concrete
{
    public class SceneryOutputDTO : ISceneryOutputDTO
    {
        public SceneryOutputDTO(Scenery scenery) : base(scenery)
        {
        }

        protected override IImageOutputDTO GetDTOImage(Image image)
        {
            return new ImageOutputDTO(image);
        }

        public static IList<SceneryOutputDTO> CreateListOf(IList<Scenery> sceneries) {
            IList<SceneryOutputDTO> result = new List<SceneryOutputDTO>(sceneries.Count);
            foreach (Scenery s in sceneries) {
                result.Add(new SceneryOutputDTO(s));
            }

            return result;
        }
    }
}
