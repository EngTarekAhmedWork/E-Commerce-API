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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public OrderDetailsController(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _work.OrderDetails.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _work.OrderDetails.GetFirstOrDefaultAsync(x => x.Id == Id);
            if (result == null)
            {
                return BadRequest($"Not Found With ID: {Id}");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("OrderDetails")]
        public async Task<IActionResult> CreateOrderDetailsAsync(OrderDetailsDto orderDetailsDto)
        {
            var existOrderDetails = _mapper.Map<OrderDetails>(orderDetailsDto);
            await _work.OrderDetails.AddAsync(existOrderDetails);
            await _work.CompleteAsync();
            return Ok(existOrderDetails);
        }

        [HttpPost]
        [Route("Order")]

        public async Task<IActionResult> CreateOrderAsync(OrderDtos orderDtos)
        {
            var order = _mapper.Map<Order>(orderDtos);
            await _work.Order.AddAsync(order);
            await _work.CompleteAsync();
            return Ok(order);
        }
    }
}
