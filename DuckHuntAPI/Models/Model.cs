using System.Collections.Generic;

namespace DuckHuntAPI.Models
{
    public abstract class Model
    {
        public abstract Dictionary<object, object> GetDTO();
    }
}
