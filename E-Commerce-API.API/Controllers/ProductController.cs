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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork , IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
        var products = await _unitOfWork.Product.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductDTO productDTO) 
        {   
            var product = _mapper.Map<Product>(productDTO);
            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return Ok(product);
        }


        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateAsync(int Id, UpdateProductDto updateProductDto) 
        {
            var product = await _unitOfWork.Product.GetFirstOrDefaultAsync(x=> x.Id == Id);
            if (product == null) 
            {
                return BadRequest($"Not Product With ID: {Id}");
            }
            product = _mapper.Map<Product>(updateProductDto);
            await _unitOfWork.Product.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();
            return Ok("Product Update Done!");

        }


        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var product = await _unitOfWork.Product.GetFirstOrDefaultAsync(x => x.Id == Id);
            if (product == null) 
            {
                return BadRequest($"Not Found Product With ID: {Id}");
            }

            await _unitOfWork.CompleteAsync();
            return Ok("Deleted Item Done!");
        }

    }
}









