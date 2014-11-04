namespace Shop.Net.Model.Marketing
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SeoAttributes
    {
        [NotMapped]
        private const int DbStringMaxLength = 400;

        [MaxLength(DbStringMaxLength)]
        public string MetaTitle { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string MetaDescription { get; set; }
    }
}