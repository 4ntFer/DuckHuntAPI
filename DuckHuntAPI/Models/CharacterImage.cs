namespace DuckHuntAPI.Models
{
    public class CharacterImage
    {
        public virtual int id { get; set; }
        public virtual Character character { get; set; }
        public virtual Image image { get; set; }
    }
}
