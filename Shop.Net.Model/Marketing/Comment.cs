namespace Shop.Net.Model.Marketing
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Shop.Net.Model.Catalog;

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

        public bool Deleted { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }
    }
}