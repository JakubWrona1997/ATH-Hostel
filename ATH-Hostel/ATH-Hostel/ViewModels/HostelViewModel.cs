using System.Collections.Generic;
using System.ComponentModel;

namespace ATH_Hostel.ViewModels
{
    public class HostelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        [DisplayName("Image")]
        public List<string> ImagePaths { get; set; }
    }
}
