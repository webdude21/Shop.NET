namespace Shop.Net.Model
{
    using System.ComponentModel.DataAnnotations;

    public class ContactInformation
    {
        private const int DbStringMaxLength = 400;

        public int Id { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string ContactPerson { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string PhoneNumber { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string FaxNumber { get; set; }

        [MaxLength(DbStringMaxLength)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Company { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Country { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string StateProvince { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string City { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Address1 { get; set; }

        [MaxLength(DbStringMaxLength)]
        public string Address2 { get; set; }

        [MaxLength(20)]
        public string ZipCode { get; set; }
    }
}