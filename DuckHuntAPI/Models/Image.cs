using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>Image<c> correspondent database Images's Table.
    // </summary>
    public class Image : ModelTranferable
    {
        public virtual int id { get; set; }
        public virtual Byte[] data { get; set; }

        public virtual Character character { get; set; }

        //TODO
        public override Dictionary<object, object> GetDTO()
        {
            throw new NotImplementedException();
        }
    }
}
