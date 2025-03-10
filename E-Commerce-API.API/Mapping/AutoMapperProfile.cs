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
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<LoginUserDto, User>().ReverseMap();
            CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();
            CreateMap<OrderDtos , Order>().ReverseMap();

            
        }
    }
}
