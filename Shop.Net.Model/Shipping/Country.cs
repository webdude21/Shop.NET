namespace Shop.Net.Model.Shipping
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country
    {
        [Key]
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string Code { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}