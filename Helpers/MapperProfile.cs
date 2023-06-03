using AutoMapper;
using proiectDAW.Models;
using proiectDAW.Models.DTO;

namespace Demo.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>();
        }

    }
}
