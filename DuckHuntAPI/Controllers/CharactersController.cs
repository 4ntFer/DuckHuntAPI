
using DuckHuntAPI.Models;
using DuckHuntAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Controllers
{
    [ApiController]
    [Route("character")]
    public class CharactersController : Controller
    {
        // Retorna todos os Characters
        // TODO
        [HttpGet]
        public IActionResult Get() {
            return BadRequest("Sem implementação");
        }
        // Retorna o character filtrando por ID
        // TODO
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            CharacterRepository repository = new CharacterRepository(session);
            Character c = repository.FindById(id);

            return BadRequest("Sem Implementação");
        }
        // Retorna as imagens do character filtrando por ID
        // TODO: uso do DTO
        [HttpGet]
        [Route("{id}/images")]
        public IActionResult GetCharacterImages(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            CharacterRepository repository = new CharacterRepository(session);
            Character c = repository.FindById(id);

            return BadRequest("Sem Implementação");
        }
        // Retorna as animações do character filtrando por ID
        //TODO
        [HttpGet]
        [Route("{id}/animations")]
        public IActionResult GetCharacterAnimations(int id) {
            return BadRequest("Sem Implementação");
        }
    }
}
