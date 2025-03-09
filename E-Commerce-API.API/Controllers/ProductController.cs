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
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork , IMapper mapper, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
        var products = await _productService.GetAllProductAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductDTO productDTO) 
        {   
            var product = _mapper.Map<Product>(productDTO);
            await _productService.CreateProductAsync(product);
            await _unitOfWork.CompleteAsync();
            return Ok(product);
        }


        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateAsync(int Id, UpdateProductDto updateProductDto) 
        {
            var product = await _productService.GetByIdAsync(Id);
            if (product == null) 
            {
                return BadRequest($"Not Product With ID: {Id}");
            }
            _mapper.Map(updateProductDto, product);
            await _productService.UpdateProductAsync(product, Id);
            await _unitOfWork.CompleteAsync();
            return Ok("Product Update Done!");

        }


        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var product = await _productService.GetByIdAsync(Id);
            if (product == null) 
            {
                return BadRequest($"Not Found Product With ID: {Id}");
            }

            await _unitOfWork.CompleteAsync();
            return Ok("Deleted Item Done!");
        }

    }
}









