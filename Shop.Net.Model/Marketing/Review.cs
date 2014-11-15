namespace Shop.Net.Model.Marketing
{
    using System.ComponentModel.DataAnnotations;

    using Shop.Net.Model.Catalog;

    public class Review
    {
        public int Id { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        [MaxLength(2000)]
        [MinLength(50)]
        public string Content { get; set; }

        public byte ShipingRating { get; set; }

        public byte QualityRating { get; set; }

        public byte CustomerServiceRating { get; set; }

        public byte PriceRating { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }
    }
}