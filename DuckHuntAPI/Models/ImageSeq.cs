namespace DuckHuntAPI.Models
{
    // <summary>
    // Class <c>ImageSeq<c> correspondent database ImageSeq's Table.
    // </summary>
    public class ImageSeq
    {
        public virtual int id { get; set; }
        public virtual int animationId { get; set; }
        public virtual int imageIndex { get; set; }
        public virtual Image image { get; set; }
    }
}
