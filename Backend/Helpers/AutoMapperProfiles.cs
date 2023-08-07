using AutoMapper;
using HSPA.Dtos;
using HSPA.Models;

namespace HSPA.Helpers
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles() {

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CityUpdateDto>().ReverseMap();
        }
    }
}
