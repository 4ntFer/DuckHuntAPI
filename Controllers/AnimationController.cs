using DuckHuntAPI.Classes;
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
            AnimationObjectFactory Factory = new AnimationObjectFactory();
            List<Animation> animationsBDList = Factory.findAll();
            List<Dictionary<string, object>> animationsReturned;

            if (animationsBDList.Count != 0)
            {
                animationsReturned = new List<Dictionary<string, object>>();
                foreach (Animation abd in animationsBDList)
                {   
                    AnimationObject aobj = new AnimationObject(abd, Factory);
                    Dictionary<string, object> ar = new Dictionary<string, object>();
                    List<string> imgUrlList = new List<string>();

                    ar["Name"] = abd.Name;
                    ar["CharacterName"] = new CharacterRepository().FindById(abd.CharacterId).name;
                    ar["Images"] = imgUrlList;

                    foreach (ImageObject imgobj in aobj.GetImages()) {
                        imgUrlList.Add(imgobj.url);
                    }

                    animationsReturned.Add(ar);
                }
                return Ok(animationsReturned);
            }

            return null;
        }
    }
}
