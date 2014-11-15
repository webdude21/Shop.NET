namespace Shop.Net.Web.Models.Rating
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Marketing;
    using Shop.Net.Resources;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class ReviewViewModel : IMapFrom<Review>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Author { get; set; }

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

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Review, ReviewViewModel>()
                .ForMember(model => model.Author, opt => opt.MapFrom(fullProduct => fullProduct.Author.UserName));
        }
    }
}