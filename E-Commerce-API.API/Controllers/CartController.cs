using AutoMapper;
using E_Commerce_API.Application.Interfaces;
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
        private readonly ICartServices _cartServices;
        private readonly IMapper _mapper;

        public CartController(IUnitOfWork work,IMapper mapper, ICartServices cartServices)
        {
            _work = work;
            _cartServices = cartServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
        return Ok(await _cartServices.GetAllAsync());  
        }

        [HttpPost]
        public async Task<IActionResult> AddToCartAsync(CartDto cartDto)
        {
            var cart = _mapper.Map<Cart>(cartDto);
            var cartInDb = await _cartServices.GetCartItemAsync(cartDto.UserId, cartDto.ProductId);

            if (cartInDb != null) 
            {
                cartInDb.Quntity += cart.Quntity;
            }
            else
            {
                await _cartServices.CreateAsync(cart);
            }
            await _work.CompleteAsync();
            return Ok(cartInDb);
        }
    } 
}
