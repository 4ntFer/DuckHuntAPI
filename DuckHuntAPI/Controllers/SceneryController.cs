using DuckHuntAPI.DTO.Concrete;
using DuckHuntAPI.Models;
using DuckHuntAPI.Repository.Abtractions;
using DuckHuntAPI.Repository.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckHuntAPI.Controllers
{
    [ApiController]
    [Route("api/scenery")]
    public class SceneryController : ControllerBase
    {
        // Retorna todos os cenários
        [HttpGet]
        [Route("")]
        public IActionResult GetAll() {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            ISceneryRepository repository = new SceneryRepository(session);
            IList<Scenery> sceneries = repository.FindAll();

            return Ok(SceneryOutputDTO.CreateListOf(sceneries));
        }

        // Retorna os cenários por nome
        [HttpGet]
        [Route("byName/{name}")]
        public IActionResult GetByName(string name) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            ISceneryRepository repository = new SceneryRepository(session);
            IList<Scenery> sceneries = repository.FindByName(name);

            return Ok(SceneryOutputDTO.CreateListOf(sceneries));
        }

        // Retorna os cenários por id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            ISceneryRepository repository = new SceneryRepository(session);
            Scenery scenery = repository.FindById(id);

            if(scenery == null)
            {
                return BadRequest($"Error: Scenery with id = {id} does not exist.");
            }

            return Ok(new SceneryOutputDTO(scenery));
        }

        // Retorna os cenários por tipo
        [HttpGet]
        [Route("byType/{type}")]
        public IActionResult GetByType(string type) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            ISceneryRepository repository = new SceneryRepository(session);
            IList<Scenery> sceneries = repository.FindByType(type);

            return Ok(SceneryOutputDTO.CreateListOf(sceneries));
        }

        // Retorna a imagem do cenário
        [HttpGet]
        [Route("{id}/image")]
        public IActionResult GetImage(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            ISceneryRepository repository = new SceneryRepository(session);
            Scenery scenery = repository.FindById(id);

            if (scenery == null)
            {
                return BadRequest($"Error: Scenery with id = {id} does not exist.");
            }

            return Ok(new SceneryOutputDTO(scenery).image);
        }
    }
}
