using ATH_Hostel.Infrastructure.Models;
using ATH_Hostel.ViewModels;
using AutoMapper;

namespace ATH_Hostel.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Room, RoomViewModel>();

            CreateMap<Room, RoomItemViewModel>();
        }
    }
}
