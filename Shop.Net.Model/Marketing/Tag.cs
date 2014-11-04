namespace Shop.Net.Model.Marketing
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Shop.Net.Model.Catalog;

    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}