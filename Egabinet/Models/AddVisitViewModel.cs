using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Egabinet.Models
{
    public class AddVisitViewModel
    {
    

    [Required]
    [Display(Name = "Doctor")]
    public string SelectedDoctor { get; set; }
    public IEnumerable<SelectListItem> Doctors { get; set; }

    [Required]
    [Display(Name = "Patient")]
    public string SelectedPatient { get; set; }
    public IEnumerable<SelectListItem> Patients { get; set; }

    [Required]
    [Display(Name = "Data")]
    public DateTime SelectedData { get; set; }

    }

}
