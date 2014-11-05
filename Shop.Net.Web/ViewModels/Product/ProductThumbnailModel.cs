namespace Shop.Net.Web.ViewModels.Product
{
    using System.Linq;

    using AutoMapper;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class ProductThumbnailModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Image Image { get; set; }

        public string FriendlyUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductThumbnailModel>()
                .ForMember(model => model.Image, opt => opt.MapFrom(fullProduct => fullProduct.Images.FirstOrDefault()));
        }
    }
}