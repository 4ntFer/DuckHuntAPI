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
    [Route("Animation")]
    public class AnimationController : Controller
    {
        // Retorna todas as Animações
        // TODO
        [HttpGet]
        public IActionResult Get() {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);

            return BadRequest("Sem implementação");
        }

        // Retorna uma animação filtrando por ID
        // TODO
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) {
            return BadRequest("Sem implementação");
        }
        // Retorna uma animação filtrando por nome
        // TODO
        [HttpGet]
        [Route("byName/{name}")]
        public IActionResult GetByName(string name) {
            return BadRequest("Sem implementação");
        }
        // Retorna as imagens da animação filtrada por id
        // TODO
        [HttpGet]
        [Route("{id}/images")]
        public IActionResult GetImagesById(int id) {
            return BadRequest("Sem implementação");
        }
        // Retorna as imagens da animação filtrada por Nome
        // TODO
        [HttpGet]
        [Route("byName/{name}/images")]
        public IActionResult GetImagesByName(string name) {
            return BadRequest("Sem implementação");
        }
    }
}
