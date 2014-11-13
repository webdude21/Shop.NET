namespace Shop.Net.Web.Models.Checkout
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Shop.Net.Model.Shipping;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CarrierDropdownViewModel : IMapFrom<Carrier>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "Money")]
        public decimal DeliveryPrice { get; set; }

        public int DeliverInDays { get; set; }

        public string Information
        {
            get
            {
                return string.Format("{0} (Shipping Rate: {1:C}, Delivery in {2} days)", this.Name, this.DeliveryPrice, this.DeliverInDays);
            }
        }
    }
}