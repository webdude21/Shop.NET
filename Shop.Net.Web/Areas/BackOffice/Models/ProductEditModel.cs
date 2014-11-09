namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AutoMapper;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Marketing;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.Catalog.Models.Product;
    using Shop.Net.Web.Infrastructure.Mapping;
    using Shop.Net.Web.Models.Marketing;

    public class ProductEditModel : SeoEditModel, IMapFrom<Product>, IHaveCustomMappings
    {
        [NotMapped]
        private const int DbStringMaxLength = 400;

        public int Id { get; set; }

        [Required]
        [MaxLength(DbStringMaxLength)]
        [MinLength(2)]
        public string Name { get; set; }

        [MaxLength(1200)]
        public string Description { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Sku { get; set; }

        [DisplayName(@"Manufacturer Part Number")]
        [MaxLength(DbStringMaxLength)]
        public string ManufacturerPartNumber { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Manufacturer { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        public decimal Price { get; set; }

        [DisplayName(@"Product Cost")]
        [Range(0, double.MaxValue, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        public decimal ProductCost { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        public double? Weight { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        public double? Height { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        public double? Length { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        public double? Width { get; set; }

        public int Quantity { get; set; }

        public bool Published { get; set; }

        [DisplayName(@"Allow Customer Reviews")]
        public bool AllowCustomerReviews { get; set; }

        [DisplayName(@"Allow Customer Comments")]
        public bool AllowCustomerComments { get; set; }

        [DisplayName(@"Allow Customer Rating")]
        public bool AllowCustomerRating { get; set; }

        public CategorySimpleViewModel Category { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
        }
    }
}