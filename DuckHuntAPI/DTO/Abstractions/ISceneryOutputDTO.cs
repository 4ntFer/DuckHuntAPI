using DuckHuntAPI.Models;
using NHibernate.Mapping.ByCode;

namespace DuckHuntAPI.DTO.Abstractions
{
    public abstract class ISceneryOutputDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public IImageOutputDTO image { get; set; }

        public ISceneryOutputDTO(Scenery scenery) {
            id = scenery.id;
            name = scenery.name;
            type = scenery.type;
            image = GetDTOImage(scenery.image);
        }
        protected abstract IImageOutputDTO GetDTOImage(Image image);
        
    }
}
