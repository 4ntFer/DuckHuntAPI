using DuckHuntAPI.DTO.Abstractions;
using DuckHuntAPI.Models;

namespace DuckHuntAPI.DTO.Concrete
{
    public class ImageOutputDTO : IImageOutputDTO
    {
        public ImageOutputDTO(Image image) : base(image)
        {
        }

        protected override string GetImageLink(Image image)
        {
            return Environment.SOURCE_URL + "/image/png?id=" + image.id;
        }
    }
}
