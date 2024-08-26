using DuckHuntAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Controllers
{
    [ApiController]
    [Route("image")]
    public class ImageController : Controller
    {
        [HttpGet]
        public IActionResult Get(int id) {
            Image ir = new ImageRepository().FindById(id);

            if (ir == null) {
                return BadRequest("Id não encontrado.");
            }

            return File(ir.data, "image/png");
        }
    }
}
