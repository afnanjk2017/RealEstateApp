using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RealEstateApp.Models
{
    public class PropertyImages : AuditEntity<Guid>
    {

        [ForeignKey("Property")]
        public int Property_Id { get; set; }


        [Required]
        public string? Image { get; set; } // image path
                                          
        // Navigation property
        public virtual Property Property { get; set; }

    }
}
