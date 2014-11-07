namespace Shop.Net.Web.Areas.Catalog.Models.Product
{
    using Shop.Net.Model.Catalog;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public string AltText { get; set; }

        public string Url { get; set; }
    }
}