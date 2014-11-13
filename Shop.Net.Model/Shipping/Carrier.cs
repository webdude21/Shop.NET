namespace Shop.Net.Model.Shipping
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Carrier
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        public string Name { get; set; }

        [Column(TypeName = "Money")]
        public decimal DeliveryPrice { get; set; }

        public int DeliverInDays { get; set; }
    }
}