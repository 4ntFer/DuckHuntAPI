using DuckHuntAPI.Models;
using DuckHuntAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System.Collections.Generic;

namespace DuckHuntAPI.Controllers
{
    [ApiController]
    [Route("image")]
    public class ImageController : Controller
    {
        // Retorna todas as Imagens
        // TODO
        [HttpGet]
        public IActionResult GetAllImages() {
            return BadRequest("Sem implementação");
        }

        // Retorna a imagem filtrada por id
        // TODO
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) {
            return BadRequest("Sem implementação");
        }

        // Retorna o personagem na imagem
        // TODO
        [HttpGet]
        [Route("{id}/character")]
        public IActionResult GetCharacter(int id) {

            return BadRequest("Sem implementação");
        }

        [HttpGet]
        [Route("png")]
        public IActionResult GetImagePng(int id) {
            ISession session = NHibernateHelper.GetSession(HttpContext);
            ImageRepository imageRepository = new ImageRepository(session);
            Image image = imageRepository.FindById(id);

            if (image == null) {
                return NotFound();
            }

            return File(image.data, "image/png");
        }
    }
}
