namespace Shop.Net.Web.Areas.Profile.Models
{
    using System.ComponentModel.DataAnnotations;

    using Shop.Net.Model.Shipping;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class ContactInformationViewModel : IMapFrom<ContactInformation>
    {
        private const int DbStringMaxLength = 400;

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(DbStringMaxLength)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(DbStringMaxLength)]
        public string ContactPerson { get; set; }

        [Required]
        [StringLength(DbStringMaxLength)]
        public string PhoneNumber { get; set; }

        [StringLength(DbStringMaxLength)]
        public string FaxNumber { get; set; }

        [StringLength(DbStringMaxLength)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(DbStringMaxLength)]
        public string Company { get; set; }

        [StringLength(DbStringMaxLength)]
        [Required]
        public string Country { get; set; }

        [StringLength(DbStringMaxLength)]
        [Required]
        public string StateProvince { get; set; }

        [StringLength(DbStringMaxLength)]
        [Required]
        public string City { get; set; }

        [StringLength(DbStringMaxLength)]
        [Required]
        public string Address1 { get; set; }

        [StringLength(DbStringMaxLength)]
        public string Address2 { get; set; }

        [StringLength(20)]
        [Required]
        public string ZipCode { get; set; }

    }
}