namespace Shop.Net.Model.Marketing
{
    public class Rating
    {
        public int Id { get; set; }

        public byte Value { get; set; }

        public virtual Review Review { get; set; }

        public int ReviewId { get; set; }
    }
}