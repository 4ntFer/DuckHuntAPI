using System.Collections.Generic;

namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>Character<c> correspondent database Character's Table.
    // </summary>
    public class Character
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual IList<CharacterImage> characterImages { get; set; }
        public virtual IList<Animation> animations { get; set; }
    }
}
