namespace Shop.Net.Web.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Shop.Net.Model.Shipping;
    using Shop.Net.Resources;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CarrierViewModel : IMapFrom<Carrier>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        [Required]
        public decimal DeliveryPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = GlobalConstants.NonNegativeNumbers)]
        [DefaultValue(1)]
        [Required]
        public int DeliverInDays { get; set; }
    }
}