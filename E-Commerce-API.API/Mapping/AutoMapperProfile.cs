using AutoMapper;
using E_Commerce_API.Core.DTOs;
using E_Commerce_API.Core.Entities;

namespace E_Commerce_API.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDto,Category>().ReverseMap();
            
        }
    }
}
