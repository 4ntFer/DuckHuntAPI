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
            List<Animation> animationsBDList = new AnimationRepository().findAll();
            List<Dictionary<string, object>> animationsReturned;

            if (animationsBDList.Count != 0)
            {
                animationsReturned = new List<Dictionary<string, object>>();
                foreach (Animation abd in animationsBDList)
                {
                    Dictionary<string, object> ar = new Dictionary<string, object>();
                    List<string> sprites;
                    List<ImageSeq> imgSeqList;

                    ar["Name"] = abd.Name;
                    ar["CharacterName"] = new CharacterRepository().FindById(abd.CharacterId).name;

                    sprites = new List<string>();
                    imgSeqList = new ImageSeqRepository().findByAnimation(abd.Id);

                    foreach (ImageSeq imgseq in imgSeqList)
                    {
                        sprites.Add(Environment.SOURCE_URL + "/image/" + imgseq.ImageId);
                    }

                    ar["Sprites"] = sprites;

                    animationsReturned.Add(ar);
                }
                return Ok(animationsReturned);
            }

            return null;
        }
    }
}
