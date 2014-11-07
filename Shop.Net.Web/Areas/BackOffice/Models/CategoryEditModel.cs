namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Shop.Net.Web.Infrastructure.Mapping;

    public class CategoryEditModel : IMapFrom<Model.Catalog.Category>
    {
        [NotMapped]
        private const int DbStringMaxLength = 200;

        public int Id { get; set; }

        [Required]
        [StringLength(DbStringMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = @"Seo Friendly Url")]
        [StringLength(DbStringMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string FriendlyUrl { get; set; }

        [Display(Name = @"Meta Title")]
        public string MetaTitle { get; set; }

        [Display(Name = @"Meta Description")]
        public string MetaDescription { get; set; }

        [Display(Name = @"Meta Keywords")]
        public string MetaKeyWords { get; set; }
    }
}