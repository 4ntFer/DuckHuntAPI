using DuckHuntAPI.ClassObjects;
using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using DuckHuntAPI.Repository;
using DuckHuntAPI.Utils;
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

            return Ok(result);
        }
    }
}
