using ATH_Hostel.Infrastructure.Enums;
using ATH_Hostel.Infrastructure.Models;

namespace ATH_Hostel.ViewModels
{
    public class RoomViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HostelId { get; set; }
        public decimal PriceForNight { get; set; }
        public int BedsAmount { get; set; }
        public RoomType RoomType { get; set; }
    }
}
