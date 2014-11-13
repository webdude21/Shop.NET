namespace Shop.Net.Web.Models.Checkout
{
    using System.ComponentModel.DataAnnotations;

    public class OrderOutputModel
    {
        [Required]
        public int ShippingInformationId { get; set; }

        [Required]
        public int CarrierId { get; set; }

        [Required]
        public int CartId { get; set; }
    }
}