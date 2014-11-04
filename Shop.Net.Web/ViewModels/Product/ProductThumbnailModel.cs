namespace Shop.Net.Web.ViewModels.Product
{
    using System.Linq;

    using AutoMapper;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class ProductThumbnailModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Image Image { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductThumbnailModel>()
                .ForMember(product => product.Image, opt => opt.MapFrom(fullProduct => fullProduct.Images.FirstOrDefault()));
        }
    }
}