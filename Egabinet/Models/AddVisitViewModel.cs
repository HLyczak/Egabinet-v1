using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Egabinet.Models
{
    public class AddVisitViewModel
    {


        [Required]
        [Display(Name = "Doctor")]
        public string SelectedDoctor { get; set; }
        public IEnumerable<SelectListItem> Doctors { get; set; }

        [Required] //wysyłka
        [Display(Name = "Patient")]  //wysyłka
        public string SelectedPatient { get; set; }  //wysyłka

        public IEnumerable<SelectListItem> Patients { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime SelectedData { get; set; }

    }





}
