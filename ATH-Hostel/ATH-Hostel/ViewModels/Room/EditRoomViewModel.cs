using ATH_Hostel.Infrastructure.Enums;

namespace ATH_Hostel.ViewModels.Room
{
    public class EditRoomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceForNight { get; set; }
        public int BedsAmount { get; set; }
        public RoomType RoomType { get; set; }
    }
}
