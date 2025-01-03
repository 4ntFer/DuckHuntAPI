using DuckHuntAPI.Models;

namespace DuckHuntAPI.DTO.Abstractions
{
    public abstract class IImageOutputDTO
    {
        public int id { get; set; }
        public string imageLink { get; set; }

        public IImageOutputDTO(Image image) {
            id = image.id;
            imageLink = GetImageLink(image);
        }
        protected abstract string GetImageLink(Image image);
    }
}
