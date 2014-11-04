namespace Shop.Net.Model.Catalog
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string MetaTitle { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        [Index(IsUnique = true)]
        public string FriendlyUrl { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }
    }
}