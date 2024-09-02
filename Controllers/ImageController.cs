using DuckHuntAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckHuntAPI.Controllers
{
    [ApiController]
    [Route("image")]
    public class ImageController : Controller
    {
        [HttpGet]
        public IActionResult GetAllImages() {
            List<Image> imagesList = new ImageRepository().FindAllImages();
            List<string> urlList;

            if (imagesList.Count == 0)
            {
                return BadRequest("Nenhuma imagem disponivel.");
            }
            else {
                urlList = new List<string>();
                foreach (Image i in imagesList)
                {
                    urlList.Add(Environment.SOURCE_URL + "/image/" + i.id);
                }

                return Ok(urlList);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) {
            Image image = new ImageRepository().FindById(id);

            if (image == null) {
                return BadRequest("Id não encontrado.");
            }

            return File(image.data, "image/png");
        }

        [HttpGet]
        [Route("ByCharacter/{CharacterName}")]
        public IActionResult GetByCharacter(string CharacterName) {
            //Character c = new CharacterRepository().FindByName(CharacterName);

            //if (c != null) {
                //TODO
            //}

            return BadRequest();
        }
        
    }
}
