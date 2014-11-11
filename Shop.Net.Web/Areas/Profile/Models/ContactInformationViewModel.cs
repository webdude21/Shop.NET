namespace Shop.Net.Web.Areas.Profile.Models
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Shop.Net.Model.Shipping;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class ContactInformationViewModel : IMapFrom<ContactInformation>, IHaveCustomMappings
    {
        private const int DbStringMaxLength = 400;

        public int Id { get; set; }

        [Required]
        [MaxLength(DbStringMaxLength)]
        public string ContactPerson { get; set; }

        [Required]
        [MaxLength(DbStringMaxLength)]
        public string PhoneNumber { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string FaxNumber { get; set; }

        [MaxLength(DbStringMaxLength)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Company { get; set; }

        public string Country { get; set; }

        [Required]
        public int CountryId { get; set; }

        [MaxLength(DbStringMaxLength)]
        [Required]
        public string StateProvince { get; set; }

        [MaxLength(DbStringMaxLength)]
        [Required]
        public string City { get; set; }

        [MaxLength(DbStringMaxLength)]
        [Required]
        public string Address1 { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Address2 { get; set; }

        [MaxLength(20)]
        [Required]
        public string ZipCode { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ContactInformation, ContactInformationViewModel>()
                .ForMember(viewModel => viewModel.Country, configure => configure.MapFrom(fullModel => fullModel.Country.Name));
        }
    }
}