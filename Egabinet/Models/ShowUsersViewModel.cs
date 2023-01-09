using System.ComponentModel.DataAnnotations;

namespace Egabinet.Models
{
    public class ShowUsersViewModel
    {

        [Display(Name = "Patient Name")]
        public string Patient { get; set; }

        [Display(Name = "Doctor Name")]
        public string Doctor { get; set; }

        [Display(Name = "Room Number")]
        public int Room { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }


        [Display(Name = "Id")]
        public string Id { get; set; }
    }
}
