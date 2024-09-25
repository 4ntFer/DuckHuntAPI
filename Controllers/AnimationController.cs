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
    [Route("Animation")]
    public class AnimationController : Controller
    {
        [HttpGet]
        public ActionResult Get() {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            RepositoryAndObjectFactorySupplier supplier = new RepositoryAndObjectFactorySupplier(session);

            CharacterRepository characterRepository = supplier.characterRepository;
            AnimationGameObjectAttributesBuilder Factory = supplier.animationObjectFactory;

            List<Animation> animationsBDList = supplier.animationRepository.findAll();
            List<Dictionary<string, object>> animationsReturned;

            if (animationsBDList.Count != 0)
            {
                animationsReturned = new List<Dictionary<string, object>>();
                foreach (Animation abd in animationsBDList)
                {   
                    AnimationGameObject aobj = new AnimationGameObject(abd, Factory);
                    Dictionary<string, object> ar = new Dictionary<string, object>();
                    List<string> imgUrlList = new List<string>();

                    ar["Name"] = abd.Name;
                    ar["CharacterName"] = characterRepository.FindById(abd.CharacterId).name;
                    ar["Images"] = imgUrlList;

                    foreach (ImageGameObject imgobj in aobj.GetImages()) {
                        imgUrlList.Add(imgobj.url);
                    }

                    animationsReturned.Add(ar);
                }
                return Ok(animationsReturned);
            }

            return null;
        }

       [HttpGet]
       [Route("{name}")]
       public IActionResult Get(string name)
       {
            NHibernate.ISession session = NHibernateHelper.GetSession(HttpContext);
            RepositoryAndObjectFactorySupplier supplier = new RepositoryAndObjectFactorySupplier(session);

            AnimationRepository animationRepository = supplier.animationRepository;
            AnimationGameObjectAttributesBuilder animationFactory = supplier.animationObjectFactory;

            Animation animation = animationRepository.findByName(name);
            AnimationGameObject animationObject;

            if (animation != null) {
                animationObject = new AnimationGameObject(animationRepository.findByName(name), animationFactory);
                List<string> imgList = new List<string>();
                foreach (ImageGameObject img in animationObject.GetImages())
                {
                    imgList.Add(img.url);
                }

                return Ok(imgList);
            }


            return BadRequest("Animation does not exist.");
       }
    }
}
