namespace ATH_Hostel.ViewModels
{
    public class RoomItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HostelId { get; set; }
        public string HostelName { get; set; }
        public decimal PriceForNight { get; set; }
        public int BedsAmount { get; set; }
    }
}
