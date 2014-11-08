namespace Shop.Net.Web.Areas.Catalog.Models.Category
{
    using Shop.Net.Web.Infrastructure.Mapping;
    using Shop.Net.Web.Models.Marketing;

    public class CategoryViewModel : SeoViewModel, IMapFrom<Model.Catalog.Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}