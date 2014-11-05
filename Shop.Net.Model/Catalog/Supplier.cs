namespace Shop.Net.Model.Catalog
{
    using System.ComponentModel.DataAnnotations;

    using Shop.Net.Model.Shipping;

    public class Supplier
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