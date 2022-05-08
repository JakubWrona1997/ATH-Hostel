using ATH_Hostel.Infrastructure.Models;
using ATH_Hostel.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATH_Hostel.Contracts
{
    public interface IHostelRepository
    {
        public Task<List<Hostel>> GetAllHostels();
    }
}
