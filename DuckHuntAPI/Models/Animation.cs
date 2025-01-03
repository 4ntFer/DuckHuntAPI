using System.Collections.Generic;

namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>Animation<c> correspondent database Animation's Table.
    // </summary>
    public class Animation
    {
        public virtual int Id { get; set; }
        public virtual int characterId { get; set; }
        public virtual string name { get; set; }
        public virtual IList<ImageSeq> imageSequence { get; set;}
    }
}
