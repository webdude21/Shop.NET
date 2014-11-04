namespace Shop.Net.Model
{
    using System.ComponentModel.DataAnnotations;

    public class PartnerInformation
    {
        private const int DbStringMaxLength = 400;
        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}