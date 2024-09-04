using DuckHuntAPI.Models;
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
        public Character Get(int id) {

            //NHibernateHelper.OpenSession(HttpContext);
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            Character character = new CharacterRepository(session).FindById(id);
            //NHibernateHelper.CloseSession(HttpContext);

            return character;
        }
    }
}
