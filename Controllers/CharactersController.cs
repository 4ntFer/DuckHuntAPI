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
            RepositoryAndObjectFactorySupplier supplier = new RepositoryAndObjectFactorySupplier(session);

            CharacterObject characterObject = new CharacterObject(supplier.characterRepository.FindById(id),
                                                                  supplier.characterObjectFactory);

            Dictionary<string, object> result = new Dictionary<string, object>();
            List<Dictionary<string, object>> AnimationsInResult = new List<Dictionary<string, object>>();

            result.Add("Id", characterObject.id);
            result.Add("Name", characterObject.name);
            result.Add("Animations", AnimationsInResult);

            foreach(AnimationObject a in characterObject.GetAnimations()) {
                //id
                //name
                //images
                Dictionary<string, object> animationInResult = new Dictionary<string, object>();
                List<string> imageUrlList = new List<string>();

                AnimationsInResult.Add(animationInResult);

                animationInResult.Add("Id", a.Id);
                animationInResult.Add("Name", a.Name);
                animationInResult.Add("Images", imageUrlList);

                foreach (ImageObject i in a.GetImages()) {
                    imageUrlList.Add(i.url);
                }
            }

            return Ok(result);
        }
    }
}
