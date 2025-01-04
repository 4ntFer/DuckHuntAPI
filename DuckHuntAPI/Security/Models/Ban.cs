using System;

namespace DuckHuntAPI.Security.Models
{
    public class Ban
    {
        public virtual int id { get; set; }
        public virtual int deviceId { get; set; }
        public virtual DateTime startTime { get; set; }
        public virtual DateTime endTime { get; set; }
    }
}
