using DuckHuntAPI.ClassObjects;
using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using DuckHuntAPI.Repository;
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
            List<Image> imagesList = new ImageRepository(NHibernateHelper.GetSession(HttpContext)).FindAllImages();
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
            Image image = new ImageRepository(NHibernateHelper.GetSession(HttpContext)).FindById(id);

            if (image == null) {
                return BadRequest("Id não encontrado.");
            }

            return File(image.data, "image/png");
        }

        [HttpGet]
        [Route("ByCharacter/{CharacterName}")]
        public IActionResult GetByCharacter(string CharacterName) {
            CharacterRepository characterRepository = new CharacterRepository(NHibernateHelper.GetSession(HttpContext));
            AnimationRepository animationRepository = new AnimationRepository(NHibernateHelper.GetSession(HttpContext));
            ImageSeqRepository imgSeqRepository = new ImageSeqRepository(NHibernateHelper.GetSession(HttpContext));
            ImageRepository imgRepository = new ImageRepository(NHibernateHelper.GetSession(HttpContext));

            AnimationGameObjectAttributesBuilder animationFactory = new AnimationGameObjectAttributesBuilder(imgSeqRepository, imgRepository);
            CharacterGameObjectAttributesBuilder charFactory = new CharacterGameObjectAttributesBuilder(characterRepository, animationRepository, animationFactory);
            CharacterGameObject c = new CharacterGameObject(characterRepository.FindByName(CharacterName), charFactory);

            if (c != null) {
                List<string> result = new List<string>();
                foreach (AnimationGameObject a in c.GetAnimations()) {
                    foreach (ImageGameObject i in a.GetImages()) {
                        result.Add(i.url);
                    }
                }

                return Ok(result);
            }

            return BadRequest();
        }
        
    }
}
