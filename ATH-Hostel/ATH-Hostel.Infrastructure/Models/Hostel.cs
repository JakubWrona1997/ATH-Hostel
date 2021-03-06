using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Hostel.Infrastructure.Models
{
    public class Hostel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
