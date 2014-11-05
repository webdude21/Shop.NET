namespace Shop.Net.Model.Marketing
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seo
    {
        [NotMapped]
        private const int DbStringMaxLength = 400;

        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string FriendlyUrl { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string MetaTitle { get; set; }

        [MaxLength(1200)]
        public string MetaDescription { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string MetaKeyWords { get; set; }
    }
}