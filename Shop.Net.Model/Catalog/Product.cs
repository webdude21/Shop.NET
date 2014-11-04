namespace Shop.Net.Model.Catalog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Shop.Net.Model.Marketing;

    public class Product
    {
        [NotMapped]
        private const int DbStringMaxLength = 400;

        private ICollection<Category> categories;

        private ICollection<Image> images;

        private ICollection<Review> reviews;

        public Product()
        {
            this.categories = new HashSet<Category>();
            this.reviews = new HashSet<Review>();
            this.images = new HashSet<Image>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(DbStringMaxLength)]
        [MinLength(2)]
        public string Name { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string MetaTitle { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string MetaDescription { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string MetaKeyWords { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Sku { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string ManufacturerPartNumber { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Column(TypeName = "Money")]
        public decimal ProductCost { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        public double? Length { get; set; }

        public double? Width { get; set; }

        public int Quantity { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public bool AllowCustomerReviews { get; set; }

        public bool AllowCustomerComments { get; set; }

        public bool AllowCustomerRating { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

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

        public virtual ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}