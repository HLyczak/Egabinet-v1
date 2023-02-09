using System.ComponentModel.DataAnnotations;

namespace Egabinet.Models
{
    public class NurseViewModel
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {1}.")]
        public string PermissionNumber { get; set; }

        public string Address { get; set; }
    }
}
