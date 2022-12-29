using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egabinet.Models.Domain
{
    public class TimeSheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public DateTime Data { get; set; }

        [ForeignKey("Patient")]
        public long PatientId { get; set; }

        public Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [ForeignKey("Room")]
        public long RoomId { get; set; }

        public Room Room { get; set; }
    }
}
