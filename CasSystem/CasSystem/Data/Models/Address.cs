namespace CasSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.Address;
    public class Address
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(MaxTextLength)]
        public string AddressText { get; set; }

        [Required]
        [MaxLength(TownLength)]
        public string Town { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
    }
}
