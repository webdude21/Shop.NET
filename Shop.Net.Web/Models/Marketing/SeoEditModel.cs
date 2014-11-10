namespace Shop.Net.Web.Models.Marketing
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Shop.Net.Model.Marketing;
    using Shop.Net.Resources;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class SeoEditModel : IMapFrom<Seo>
    {
        [NotMapped]
        private const int DbStringMaxLength = 400;

        [Required]
        [Display(Name = @"Seo Friendly Url")]
        [StringLength(DbStringMaxLength, ErrorMessage = @"The {0} must be at least {2} characters long.",
            MinimumLength = 2)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegexValidator,
            ErrorMessage = GlobalConstants.FriendlyUrlsValidatorErrorMessage)]
        public string FriendlyUrl { get; set; }

        [StringLength(DbStringMaxLength)]
        [Display(Name = @"Meta Title")]
        public string MetaTitle { get; set; }

        [Display(Name = @"Meta Description")]
        [StringLength(2000)]
        public string MetaDescription { get; set; }

        [StringLength(DbStringMaxLength)]
        [Display(Name = @"Meta Keywords")]
        public string MetaKeyWords { get; set; }
    }
}