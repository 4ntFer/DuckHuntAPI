using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>Character<c> correspondent database Character's Table.
    // </summary>
    public class Character : Model
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual IList<Image> images { get; set; }

        public override Dictionary<object, object> GetDTO()
        {
            Dictionary<object,object> result = new Dictionary<object,object>();
            IList<Dictionary<object, object>> resultImages = new List<Dictionary<object, object>>();
            result.Add("id", id);
            result.Add("name", name);
            
            foreach (Image i in images) {
                Dictionary<object, object> iDTO = new Dictionary<object, object>();
                iDTO.Add("id", i.id);
                iDTO.Add("data", i.data);
                resultImages.Add(iDTO);
            }

            result.Add("images", resultImages);
            return result;
        }
    }
}
