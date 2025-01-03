using DuckHuntAPI.DTO.Concrete;
using DuckHuntAPI.Models;
using DuckHuntAPI.Repository;
using DuckHuntAPI.Repository.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Controllers
{
    [ApiController]
    [Route("api/animation")]
    public class AnimationController : Controller
    {
        // Retorna todas as Animações
        [HttpGet]
        public IActionResult GetAll() {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            AnimationRepository repository = new AnimationRepository(session);

            return Ok(
                AnimationOutputDTO.CreateListOf(
                    repository.FindAll()
                    )
                );
        }

        // Retorna uma animação filtrando por ID
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            AnimationRepository repository = new AnimationRepository(session);
            Animation result = repository.FindById(id);

            if (result == null)
                return BadRequest($"Animation with id = {id} does not exist.");

            return Ok(new AnimationOutputDTO(result));
        }

        // Retorna uma animação filtrando por nome
        [HttpGet]
        [Route("byName/{name}")]
        public IActionResult GetByName(string name) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            AnimationRepository repository = new AnimationRepository(session);
            IList<Animation> result = repository.FindByName(name);

            return Ok(AnimationOutputDTO.CreateListOf(result));
        }

        // Retorna as imagens da animação filtrada por id
        [HttpGet]
        [Route("{id}/images")]
        public IActionResult GetImagesById(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            AnimationRepository repository = new AnimationRepository(session);
            Animation result = repository.FindById(id);
            AnimationOutputDTO animationOutputDTO;

            if (result == null)
                return BadRequest($"Animation with id = {id} does not exist.");

            animationOutputDTO = new AnimationOutputDTO(result);
            return Ok(animationOutputDTO.framesImageLink);
        }
    }
}
