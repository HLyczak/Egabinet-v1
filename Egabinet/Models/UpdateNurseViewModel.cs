using Microsoft.AspNetCore.Identity;

namespace Egabinet.Models
{
    public class UpdateNurseViewModel
    {

            public string Id { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Role { get; set; }

        
    }


}

