using ATH_Hostel.Infrastructure.Models;
using ATH_Hostel.ViewModels;
using ATH_Hostel.ViewModels.Room;
using AutoMapper;

namespace ATH_Hostel.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Room, RoomViewModel>();

            CreateMap<Room, RoomItemViewModel>();

            CreateMap<Room, CreateRoomViewModel>().ReverseMap();

            CreateMap<EditRoomViewModel, Room>().ReverseMap();                
        }
    }
}
