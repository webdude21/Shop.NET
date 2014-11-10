namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using Shop.Net.Model.Catalog;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class ProductsListModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool Published { get; set; }

        public virtual CategorySimpleViewModel Category { get; set; }
    }
}