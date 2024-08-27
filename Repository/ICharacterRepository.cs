using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    public interface ICharacterRepository
    {
        public Character FindById(int id);
    }
}
