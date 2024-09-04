using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>Image<c> correspondent database Images's Table.
    // </summary>
    public class Image
    {
        public virtual int id { get; set; }
        public virtual Byte[] data { get; set; }
    }
}
