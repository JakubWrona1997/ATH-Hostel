using ATH_Hostel.Contracts;
using ATH_Hostel.Infrastructure.Models;
using ATH_Hostel.ViewModels;
using ATH_Hostel.ViewModels.Room;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Hostel.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HostelDBContext _dbContext;
        private readonly IMapper _mapper;

        public RoomRepository(HostelDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task CreateRoom(CreateRoomViewModel roomViewModel)
        {
            var room = _mapper.Map<Room>(roomViewModel);
            _dbContext.Add(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            if(room == null)
            {
                throw new NullReferenceException();
            }
            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditRoom(EditRoomViewModel roomViewModel, int id)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            if(room == null)
            {
                throw new NullReferenceException();
            }
            room.Name = roomViewModel.Name;
            room.Description = roomViewModel.Description;
            room.PriceForNight = roomViewModel.PriceForNight;
            room.BedsAmount = roomViewModel.BedsAmount;
            room.RoomType = roomViewModel.RoomType;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<RoomItemViewModel>> GetAllRooms()
        {
            var hostelDBContext = await _dbContext.Rooms.Include(r => r.Hostel).ToListAsync();
            if(hostelDBContext == null)
            {
                return null;
            }
            var roomlItemViewModel = _mapper.Map<List<RoomItemViewModel>>(hostelDBContext);

            return roomlItemViewModel;
        }

        public async Task<RoomViewModel> GetRoomById(int id)
        {
            var room = await _dbContext.Rooms
                .Include(r => r.Hostel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if(room == null)
            {
                return null;
            }
            var roomlViewModel = _mapper.Map<RoomViewModel>(room);

            return roomlViewModel;
        }

        public async Task<EditRoomViewModel> GetRoomToEdit(int id)
        {
            var room = await _dbContext.Rooms
               .Include(r => r.Hostel)
               .FirstOrDefaultAsync(m => m.Id == id);
            if(room == null)
            {
                return null;
            }
            var editRoom = _mapper.Map<EditRoomViewModel>(room);
            return editRoom;
        }
    }
}
