﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>Animation<c> correspondent database Animation's Table.
    // </summary>
    public class Animation
    {
        public virtual int Id { get; set; }
        public virtual int CharacterId {get; set;}
        public virtual string Name { get; set; }
        public virtual int ImageSeqId { get; set; }
    }
}
