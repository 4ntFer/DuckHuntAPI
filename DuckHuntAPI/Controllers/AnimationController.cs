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
        [HttpGet]
        public ActionResult Get() {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);

            return null;
        }

       [HttpGet]
       [Route("{name}")]
       public IActionResult Get(string name)
       {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);


            return BadRequest("Animation does not exist.");
       }
    }
}
