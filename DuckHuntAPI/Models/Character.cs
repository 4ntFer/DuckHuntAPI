using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>Character<c> correspondent database Character's Table.
    // </summary>
    public class Character
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual IList<Image> images { get; set; }
        public virtual IList<Animation> animations { get; set; }
    }
}
