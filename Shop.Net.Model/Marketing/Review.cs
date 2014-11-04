namespace Shop.Net.Model.Marketing
{
    using System.ComponentModel.DataAnnotations;

    using Shop.Net.Model.Catalog;

    public class Review
    {
        public int Id { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        [MaxLength(2000)]
        [MinLength(2)]
        public string Content { get; set; }

        public Rating Shiping { get; set; }

        public Rating Quality { get; set; }

        public Rating CustomerService { get; set; }

        public Rating Price { get; set; }

        public virtual Product Product { get; set; }
    }
}