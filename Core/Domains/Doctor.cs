using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Doctor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required]
        [ForeignKey("Specialization")]
        public string SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        [Required]
        public string PermissionNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Adress { get; set; }
        public ICollection<TimeSheet> TimeSheet { get; set; }

    }
}
