using System;

namespace DuckHuntAPI.Security.Models
{
    public class Device
    {
        public virtual int id { get; set; }
        public virtual string ip { get; set; }
        public virtual int banned { get; set; }
        public virtual DateTime firstAccess { get; set; }
        public virtual int accesses { get; set; }
    }
}
