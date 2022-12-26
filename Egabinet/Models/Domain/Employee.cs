using Microsoft.AspNetCore.Identity;

namespace Egabinet.Models.Domain
{
    public class Employee : IdentityUser
    {
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
    }
}
