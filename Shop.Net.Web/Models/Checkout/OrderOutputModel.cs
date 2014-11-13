namespace Shop.Net.Web.Models.Checkout
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class OrderOutputModel
    {
        [Required(ErrorMessage = @"You should select a shipping address. You can add one via the 'My addresses menu'")]
        [DisplayName(@"Shipping Address")]
        public int ShippingInformationId { get; set; }

        [Required]
        [DisplayName(@"Delivery Service")]
        public int CarrierId { get; set; }
    }
}