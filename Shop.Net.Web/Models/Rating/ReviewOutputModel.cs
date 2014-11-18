namespace Shop.Net.Web.Models.Rating
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Shop.Net.Resources;

    public class ReviewOutputModel
    {
        [Required]
        [MaxLength(2000)]
        [MinLength(50)]
        public string Content { get; set; }

        [DisplayName(@"Shipping")]
        [Range(0, 5, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        [DefaultValue(3)]
        public byte ShipingRating { get; set; }

        [DisplayName(@"Product Quality")]
        [Range(0, 5, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        [DefaultValue(3)]
        public byte QualityRating { get; set; }

        [DisplayName(@"Customer Service")]
        [Range(0, 5, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        [DefaultValue(3)]
        public byte CustomerServiceRating { get; set; }

        [DisplayName(@"Price")]
        [Range(0, 5, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        [DefaultValue(3)]
        public byte PriceRating { get; set; }

        public int ProductId { get; set; }
    }
}