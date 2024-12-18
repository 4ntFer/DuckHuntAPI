using System.Collections.Generic;

namespace DuckHuntAPI.Models
{
    public abstract class ModelTranferable
    {
        public abstract Dictionary<object, object> GetDTO();
    }
}
