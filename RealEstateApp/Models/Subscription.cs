using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int numOfAllowedProperty { get; set; }
        [Required]

        public decimal Price { get; set; }
    }
}
