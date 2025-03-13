using AutoMapper;
using E_Commerce_API.Application.Services;
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
        private readonly IOrderService _orderService;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IMapper _mapper;

        public OrderDetailsController(IUnitOfWork work, IMapper mapper, IOrderDetailsService orderDetailsService, IOrderService orderService)
        {
            _work = work;
            _mapper = mapper;
            _orderService = orderService;
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _orderService.GetAllOrderAsync());
        }

        [HttpGet]
        [Route("{Id}")]

        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var result = await _orderService.GetByIdAsync(Id);
            if (result == null)
            {
                return BadRequest($"Not Found With ID: {Id}");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("Order")]
        public async Task<IActionResult> CreateOrderAsync(OrderDtos orderDto)
        {
            var newOrderdb = _mapper.Map<Order>(orderDto);
            var newOrder = _orderService.CreateOrderAsync(newOrderdb);
            foreach (var item in orderDto.OrderDetails)
            {
                var newOrderdetails = _mapper.Map<OrderDetails>(item);
                newOrderdetails.OrderId = newOrder.Id;
                await _orderDetailsService.CreateOrderDetailsAsync(newOrderdetails);
            }
            await _work.CompleteAsync();
            newOrder =  _work.Order.GetFirstOrDefaultAsync(o => o.Id == newOrder.Id, "Details");
            return Ok(newOrder);
        }
    }
}
