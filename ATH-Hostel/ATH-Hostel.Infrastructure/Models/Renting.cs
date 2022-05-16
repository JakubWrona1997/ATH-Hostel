using ATH_Hostel.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Hostel.Infrastructure.Models
{
    public class Renting
    {
        public int Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset BeginDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public RentStatus Status { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
