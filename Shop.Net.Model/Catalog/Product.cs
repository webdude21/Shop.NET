namespace Shop.Net.Model.Catalog
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        private ICollection<Category> categories;

        public Product()
        {
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(400)]
        [MinLength(2)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string MetaTitle { get; set; }

        [MaxLength(400)]
        public string Sku { get; set; }

        [MaxLength(400)]
        public string ManufacturerPartNumber { get; set; }

        /// <summary>
        /// Prices
        /// </summary>
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Column(TypeName = "Money")]
        public decimal ProductCost { get; set; }

        [Column(TypeName = "Money")]
        public decimal SpecialPrice { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<Category> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }
    }
}