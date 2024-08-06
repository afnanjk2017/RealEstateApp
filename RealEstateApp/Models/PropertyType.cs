using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RealEstateApp.Models
{
    public class PropertyType : AuditEntity<Guid>
    {

        [Required]
        public string TypeName { get; set; }


    }
}
