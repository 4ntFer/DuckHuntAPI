using DuckHuntAPI.DTO.Concrete;
using DuckHuntAPI.Models;
using DuckHuntAPI.Repository;
using DuckHuntAPI.Repository.Concrete;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System.Collections.Generic;

namespace DuckHuntAPI.Controllers
{
    [ApiController]
    [Route("api/image")]
    public class ImageController : Controller
    {
        // Retorna todas as Imagens
        [HttpGet]
        public IActionResult GetAll() {
            ISession session = NHibernateHelper.GetSession(HttpContext);
            ImageRepository imageRepository = new ImageRepository(session);

            return Ok(
                ImageOutputDTO.CreateListOf(
                    imageRepository.FindAll()
                    )
                );
        }

        // Retorna a imagem filtrada por id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) {
            ISession session = NHibernateHelper.GetSession(HttpContext);
            ImageRepository imageRepository = new ImageRepository(session);
            Image result = imageRepository.FindById(id);

            if (result == null)
                return BadRequest($"Image with id = {id} does not exist");

            return Ok(new ImageOutputDTO(result));
        }
    }
}
