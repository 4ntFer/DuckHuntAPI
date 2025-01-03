
using DuckHuntAPI.DTO.Concrete;
using DuckHuntAPI.Models;
using DuckHuntAPI.Repository.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Controllers
{
    [ApiController]
    [Route("api/character")]
    public class CharactersController : Controller
    {
        // Retorna todos os Characters
        [HttpGet]
        public IActionResult GetAll() {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            CharacterRepository repository = new CharacterRepository(session);

            return Ok(
                CharacterOutputDTO.CreateListOf(
                    repository.FindAll()
                    )
                );
        }

        // Retorna o character filtrando por ID
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            CharacterRepository repository = new CharacterRepository(session);
            Character result = repository.FindById(id);

            if (result == null)
                return BadRequest($"Character with id = {id} does not exist.");

            return Ok(new CharacterOutputDTO(result));
        }

        // Retorna as imagens do character filtrando por ID
        [HttpGet]
        [Route("{id}/images")]
        public IActionResult GetCharacterImages(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            ImageRepository repository = new ImageRepository(session);
            IList<Image> result = repository.OfCharacter(id);

            return Ok(ImageOutputDTO.CreateListOf(result));
        }

        // Retorna as animações do character filtrando por ID
        [HttpGet]
        [Route("{id}/animations")]
        public IActionResult GetCharacterAnimations(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            AnimationRepository repository = new AnimationRepository(session);
            IList<Animation> result = repository.OfCharacter(id);

            return Ok(AnimationOutputDTO.CreateListOf(result));
        }
    }
}
