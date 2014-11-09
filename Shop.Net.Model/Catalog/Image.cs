namespace Shop.Net.Model.Catalog
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string FileName { get; set; }

        [MaxLength(50)]
        public string MimeType { get; set; }

        [MaxLength(300)]
        public string Url { get; set; }

    }
}