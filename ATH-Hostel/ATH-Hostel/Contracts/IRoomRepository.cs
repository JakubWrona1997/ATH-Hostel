using ATH_Hostel.Infrastructure.Models;
using ATH_Hostel.ViewModels;
using ATH_Hostel.ViewModels.Room;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATH_Hostel.Contracts
{
    public interface IRoomRepository
    {
        public Task<List<RoomItemViewModel>> GetAllRooms();
        public Task<RoomViewModel> GetRoomById(int id);
        public Task<EditRoomViewModel> GetRoomToEdit(int id);
        public Task CreateRoom(CreateRoomViewModel roomViewModel);
        public Task EditRoom(EditRoomViewModel roomViewModel, int id);
        public Task DeleteRoom(int id);
    }
}
