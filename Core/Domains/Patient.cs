using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public long _pesel;


        public long Pesel
        {
            get => _pesel;

            set
            {
                if (value < 11)
                {
                    throw new ArgumentException("Błędne dane");
                }

                _pesel = value;
            }
        }

        public string Address { get; set; }
        public ICollection<TimeSheet> TimeSheet { get; set; }
    }
}
