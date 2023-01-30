using System.ComponentModel.DataAnnotations;

namespace Egabinet.Models
{
    public class ShowUsersViewModel
    {

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "User Surname")]
        public string UserSurname { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        [Display(Name = "Id")]
        public string Id { get; set; }
    }
}
