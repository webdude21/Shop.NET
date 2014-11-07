namespace Shop.Net.Web.Areas.Catalog.Models.Product
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Marketing;
    using Shop.Net.Web.Areas.Catalog.Models.Category;
    using Shop.Net.Web.Infrastructure.Mapping;
    using Shop.Net.Web.ViewModels;

    public class ProductDetailsModel : SeoViewModel, IMapFrom<Product> 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Sku { get; set; }

        public string ManufacturerPartNumber { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public int Quantity { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public ImageViewModel FirstImage { get; set; }

        public CategoryViewModel Category { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductDetailsModel>()
                   .ForMember(model => model.FirstImage, opt => opt.MapFrom(fullProduct => fullProduct.Images.FirstOrDefault()));
        }
    }
}