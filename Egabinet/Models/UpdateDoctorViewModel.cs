using System.ComponentModel.DataAnnotations;

namespace Egabinet.Models
{
    public class UpdateDoctorViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {1}.")]
        public string PermissionNumber { get; set; }
        [Required]
        [MinLength(3)]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Surname { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        [MinLength(3)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Adress { get; set; }



        public UpdateDoctorViewModel ToDoctor() => new UpdateDoctorViewModel()
        {
            Name = Name,
            Surname = Surname,
            PermissionNumber = PermissionNumber,
            Adress = Adress
        };
    }
}


