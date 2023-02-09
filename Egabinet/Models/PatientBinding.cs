using System.ComponentModel.DataAnnotations;

namespace Egabinet.Models
{
    public class PatientBinding
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }


        [Required]
        [MinLength(3)]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Surname { get; set; }



        [MinLength(3)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Address { get; set; }

        public PatientBinding ToPatient() => new PatientBinding()
        {
            Name = Name,
            Surname = Surname,
            Address = Address
        };
    }
}
