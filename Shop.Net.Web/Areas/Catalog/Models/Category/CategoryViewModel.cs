namespace Shop.Net.Web.Areas.Catalog.Models.Category
{
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Model.Catalog.Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FriendlyUrl { get; set; }
    }
}