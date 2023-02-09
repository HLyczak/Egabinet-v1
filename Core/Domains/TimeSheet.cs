using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class TimeSheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public DateTime Data { get; set; }

        [ForeignKey("Patient")]
        public string PatientId { get; set; }

        public Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [ForeignKey("Room")]
        public string RoomId { get; set; }

        public Room Room { get; set; }
    }
}
