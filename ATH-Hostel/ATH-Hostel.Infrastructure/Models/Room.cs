using ATH_Hostel.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Hostel.Infrastructure.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [ForeignKey("Hostel")]
        public int HostelId { get; set; }
        public Hostel Hostel { get; set; }
        
        public decimal PriceForNight { get; set; }
        public int BedsAmount { get; set; }
        public RoomType RoomType { get; set; }

        public virtual ICollection<Renting> Rentings { get; set; }
    }
}
