using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RealEstateApp.Models
{
    public class User : AuditEntity<Guid>
    {

        [Required]
        public string Name { get; set; }

       
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Phone { get; set; }

        public string? Location { get; set; }

        [DefaultValue(0)]
        public int NumOfAddedPropertys { get; set; } = 0;

        [ForeignKey("Subscription")]
        public int Subscription_id { get; set; }

        public string? ProfileImage { get; set; }

        // Navigation property
        public virtual Subscription Subscription { get; set; }
    }
}
