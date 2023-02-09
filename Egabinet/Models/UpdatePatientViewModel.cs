using System.ComponentModel.DataAnnotations;

namespace Egabinet.Models
{
    public class UpdatePatientViewModel
    {
        [Required]
        public string Id { get; set; }


        [MinLength(3)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Address { get; set; }

        public PatientBinding ToPatient() => new PatientBinding()
        {
            Address = Address
        };

    }
}





