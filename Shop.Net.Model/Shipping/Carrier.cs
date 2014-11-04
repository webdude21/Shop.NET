namespace Shop.Net.Model.Shipping
{
    using System.ComponentModel.DataAnnotations;

    public class Carrier
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}