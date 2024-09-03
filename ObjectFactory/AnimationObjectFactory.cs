using DuckHuntAPI.ClassObjects;
using DuckHuntAPI.Models;
using DuckHuntAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ObjectFactory
{

    public class AnimationObjectFactory
    {
        private ImageSeqRepository ImgSeqRepos;
        private ImageRepository ImgRepos;

        public AnimationObjectFactory(ImageSeqRepository ImgSeqRepos, ImageRepository ImgRepos) {
            this.ImgSeqRepos = ImgSeqRepos;
            this.ImgRepos = ImgRepos;
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
