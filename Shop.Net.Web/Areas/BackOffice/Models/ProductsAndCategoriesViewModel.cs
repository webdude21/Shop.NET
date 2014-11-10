namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using System.Collections.Generic;

    public class ProductsAndCategoriesViewModel
    {
        public IEnumerable<CategorySimpleViewModel> Categories { get; set; }

        public ProductEditModel Product { get; set; }
    }
}