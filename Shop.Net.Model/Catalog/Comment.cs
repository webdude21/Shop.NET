namespace Shop.Net.Model.Catalog
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Author { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        [Required]
        [MaxLength(400)]
        [MinLength(2)]
        public string Content { get; set; }
    }
}