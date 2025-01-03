namespace DuckHuntAPI.Models
{
    public class Scenery
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string type { get; set; }
        public virtual Image image { get; set; }
    }
}
