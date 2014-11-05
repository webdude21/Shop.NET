namespace Shop.Net.Web.ViewModels.Product
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Marketing;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class ProductDetailsModel : IMapFrom<Product>
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

        [MaxLength(DbStringMaxLength)]
        public string ManufacturerPartNumber { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Manufacturer { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Column(TypeName = "Money")]
        public decimal ProductCost { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public int Quantity { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public Category Category { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}