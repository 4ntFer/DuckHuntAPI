using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>ImageSeq<c> correspondent database ImageSeq's Table.
    // </summary>
    public class ImageSeq
    {
        public virtual int Id { get; set; }
        public virtual int AnimationId { get; set; }
        public virtual int ImageIndex { get; set; }
        public virtual int ImageId { get; set; }

        public override bool Equals(object obj)
        {
            var t = obj as ImageSeq;
            if (t == null)
            {
                return false;
            }

            return (AnimationId == t.AnimationId && ImageIndex == t.ImageIndex);
        }
        public override int GetHashCode()
        {
            return (AnimationId + "|" + ImageIndex).GetHashCode();
        }
    }
}
