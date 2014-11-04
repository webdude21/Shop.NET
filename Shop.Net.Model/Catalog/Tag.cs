namespace Shop.Net.Model.Catalog
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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