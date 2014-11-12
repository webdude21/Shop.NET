namespace Shop.Net.Web.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Web.Areas.Catalog.Models.Product;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CartProductViewModel : IMapFrom<Product>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FriendlyUrl { get; set; }

        public string Sku { get; set; }

        public ImageViewModel FirstImage { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            
            configuration.CreateMap<Product, ProductDetailsModel>()
                   .ForMember(model => model.FirstImage, opt => opt.MapFrom(fullProduct => fullProduct.Images.FirstOrDefault()));
        }
    }
}