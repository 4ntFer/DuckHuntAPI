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
    public class AnimationGameObjectAttributesBuilder
    {
        private ImageSeqRepository ImgSeqRepos;
        private ImageRepository ImgRepos;

        public AnimationGameObjectAttributesBuilder(ImageSeqRepository ImgSeqRepos, ImageRepository ImgRepos) {
            this.ImgSeqRepos = ImgSeqRepos;
            this.ImgRepos = ImgRepos;
        }

        public AnimationGameObjectAttributesBuilder(HttpContext context) {
            ImgRepos = new ImageRepository(NHibernateHelper.GetSession(context));
            ImgSeqRepos = new ImageSeqRepository(NHibernateHelper.GetSession(context));
        }
        public List<ImageGameObject> BuildImagesOf(int AnimationId) {
            List<ImageGameObject> ImgObjList;
            List<ImageSeq> imgSeqList;

            ImgObjList = new List<ImageGameObject>();
            imgSeqList = ImgSeqRepos.FindByAnimarionId(AnimationId);

            foreach (ImageSeq imgseq in imgSeqList)
            {
                ImgObjList.Add(new ImageGameObject(ImgRepos.FindById(imgseq.ImageId)));
            }

            return ImgObjList;
        }
    }

}
