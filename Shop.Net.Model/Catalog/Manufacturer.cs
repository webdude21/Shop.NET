namespace Shop.Net.Model.Catalog
{
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        private const int DbStringMaxLength = 400;

        public int Id { get; set; }

        [Required]
        [MaxLength(DbStringMaxLength)]
        [MinLength(2)]
        public string Name { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }

        public int ContactInformationId { get; set; }
    }
}