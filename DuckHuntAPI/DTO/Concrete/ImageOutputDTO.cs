using DuckHuntAPI.DTO.Abstractions;
using DuckHuntAPI.Models;
using System.Collections.Generic;

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

        public static IList<IImageOutputDTO> CreateListOf(IList<Image> imagesList)
        {
            IList<IImageOutputDTO> result = new List<IImageOutputDTO>();

            foreach (Image img in imagesList)
            {
                result.Add(new ImageOutputDTO(img));
            }

            return result;
        }
    }
}
