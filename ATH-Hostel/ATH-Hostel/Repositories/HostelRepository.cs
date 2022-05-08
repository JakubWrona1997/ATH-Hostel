using ATH_Hostel.Contracts;
using ATH_Hostel.Infrastructure;
using ATH_Hostel.Infrastructure.Models;
using ATH_Hostel.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATH_Hostel.Repositories
{
    public class HostelRepository : IHostelRepository
    {
        private readonly HostelDBContext _dbContext;
        private readonly IMapper _mapper;

        public HostelRepository(HostelDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<List<Hostel>> GetAllHostels()
        {
            var hostel = await _dbContext.Hostels.ToListAsync();
            //var hostelItemViewModel = _mapper.Map<List<HostelItemViewModel>>(hostel);
            return hostel;
        }
    }
}
