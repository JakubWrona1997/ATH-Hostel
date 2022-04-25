namespace ATH_Hostel.ViewModels
{
    public class HostelItemViewModel
    {
        public HostelItemViewModel()
        {

        }
        public HostelItemViewModel(HostelViewModel hostelViewModel)
        {
            this.Hostel = hostelViewModel;
        }

        public int Id { get; set; }
        public HostelViewModel Hostel { get; set; }
        public string ImagePath { get; set; }
    }
}
