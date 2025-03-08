using AutoMapper;
using E_Commerce_API.Core.DTOs;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() 
    {
        var result = await _unitOfWork.Category.GetAllAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoryDto categoryDto) 
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _unitOfWork.Category.AddAsync(category);
        await _unitOfWork.CompleteAsync();
        return Ok("Create Category Sccessed!");
    }
    [HttpPut]
    [Route("{Id}")]
    public async Task<IActionResult> UpdateCategory(int Id, UpdateCategoryDto updateCategoryDto) 
    { 
    var category = await _unitOfWork.Category.GetFirstOrDefaultAsync(x=>x.Id == Id);
        if (category == null) 
        {
            return BadRequest($"Not Found Categroy With Id: {Id}");
        }
        category = _mapper.Map<Category>(updateCategoryDto);
        await _unitOfWork.Category.UpdateAsync(category);
        await _unitOfWork.CompleteAsync();
        return Ok("Update Is Sccessed");
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeleteAsync(int Id) 
    {
    var category = await _unitOfWork.Category.GetFirstOrDefaultAsync(x=> x.Id == Id);
        if (category == null) 
        {
        return BadRequest($"Not Found Categroy With Id: {Id}");
        }
       await _unitOfWork.Category.DeleteAsync(category);
        await _unitOfWork.CompleteAsync();
        return Ok("Delete Complete");

    
    }

}








