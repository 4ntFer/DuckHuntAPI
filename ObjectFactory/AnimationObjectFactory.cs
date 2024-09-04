using DuckHuntAPI.ClassObjects;
using DuckHuntAPI.Models;
using DuckHuntAPI.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ObjectFactory
{
    // <summary>
    // Class <c>AnimationObjectFactory<c> CharacterAnimation's properties builder. The buid is make through the repositories.
    // </summary>
    public class AnimationObjectFactory
    {
        private ImageSeqRepository ImgSeqRepos;
        private ImageRepository ImgRepos;

        public AnimationObjectFactory(ImageSeqRepository ImgSeqRepos, ImageRepository ImgRepos) {
            this.ImgSeqRepos = ImgSeqRepos;
            this.ImgRepos = ImgRepos;
        }

        public AnimationObjectFactory(HttpContext context) {
            ImgRepos = new ImageRepository(NHibernateHelper.GetSession(context));
            ImgSeqRepos = new ImageSeqRepository(NHibernateHelper.GetSession(context));
        }
        public List<ImageObject> GetImagesOf(int AnimationId) {
            List<ImageObject> ImgObjList;
            List<ImageSeq> imgSeqList;

            ImgObjList = new List<ImageObject>();
            imgSeqList = ImgSeqRepos.FindByAnimarionId(AnimationId);

            foreach (ImageSeq imgseq in imgSeqList)
            {
                ImgObjList.Add(new ImageObject(ImgRepos.FindById(imgseq.ImageId)));
            }

            return ImgObjList;
        }
    }

}
