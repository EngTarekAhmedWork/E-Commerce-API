using AutoMapper;
using E_Commerce_API.Core.DTOs;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public CartController(IUnitOfWork work,IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
        return Ok(await _work.Cart.GetAllAsync());  
        }

        [HttpPost]
        public async Task<IActionResult> AddToCartAsync(CartDto cartDto) 
        {
            if (cartDto.Quntity > 0) 
            {
                cartDto.Quntity += cartDto.Quntity;
            }
            var cart = _mapper.Map<Cart>(cartDto);
            await _work.Cart.AddAsync(cart);
            return Ok(cart);
        }
    } 
}
