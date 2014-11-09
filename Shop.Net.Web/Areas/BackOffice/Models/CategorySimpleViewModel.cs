namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using Shop.Net.Model.Catalog;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CategorySimpleViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}