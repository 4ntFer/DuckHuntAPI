using DuckHuntAPI.Models;
using DuckHuntAPI.Repository.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace DuckHuntAPI.Controllers
{
    [Route("/imagefile")]
    [ApiController]
    public class ImageFileController : ControllerBase
    {
        // Retorna arquivo png da imagem
        [HttpGet]
        public IActionResult GetImagePng(int id)
        {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            ImageRepository imageRepository = new ImageRepository(session);
            Image result = imageRepository.FindById(id);

            if (result == null)
            {
                return BadRequest();
            }

            return File(result.data, "image/png");
        }
    }
}
