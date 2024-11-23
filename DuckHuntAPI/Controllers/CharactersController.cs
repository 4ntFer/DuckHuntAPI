
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
        [HttpGet]
        public ActionResult Get(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);

            return Ok(null);
        }

        [HttpGet]
        [Route("{id}/images")]
        public IActionResult GetCharacterImages(int id) {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            CharacterRepository repository = new CharacterRepository(session);


            return Ok(repository.FindById(id).images);
        }
    }
}
