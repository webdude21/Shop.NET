namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Web.Infrastructure.Mapping;
    using Shop.Net.Web.Models.Marketing;

    public class CategoryEditModel : SeoEditModel, IMapFrom<Category>
    {
        [NotMapped]
        private const int DbStringMaxLength = 200;

        public int Id { get; set; }

        [Required]
        [StringLength(DbStringMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.",
            MinimumLength = 2)]
        public string Name { get; set; }
    }
}