using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RealEstateApp.Models
{
    public class UserLikedProperty : AuditEntity<Guid>
    {

        [ForeignKey("User")]
        public string User_Id { get; set; }

        [ForeignKey("Property")]
        public Guid Property_Id { get; set; }
        public virtual User User { get; set; }
        public virtual Property Property { get; set; }

    }
}
