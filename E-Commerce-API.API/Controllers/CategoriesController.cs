using AutoMapper;
using E_Commerce_API.Core.DTOs;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace E_Commerce_API.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService categoryService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _categoryService = categoryService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _categoryService.GetAllCategoryAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);

        await _categoryService.CreateCategoryAsync(category);
        await _unitOfWork.CompleteAsync();
        return Ok("Create Category Sccessed!");
    }

    [HttpPut]
    [Route("{Id}")]
    public async Task<IActionResult> UpdateCategory(int Id, UpdateCategoryDto updateCategoryDto)
    {
        var category = await _categoryService.GetByIdAsync(Id);
        if (category == null)
        {
            return BadRequest($"Not Found Categroy With Id: {Id}");
        }
        //Wrong mapping method:
        //category = _mapper.Map<Category>(updateCategoryDto);

        //Right method is:
        //1- Do not replace the entity object with a new instance.
        //2- Use _mapper.Map(source, destination) to update only properties.
        _mapper.Map(updateCategoryDto, category);
        await _categoryService.UpdateCategoryAsync(Id, category);
        await _unitOfWork.CompleteAsync();
        return Ok("Update Is Sccessed");
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> DeleteAsync(int Id)
    {
        var category = await _categoryService.GetByIdAsync(Id);
        if (category == null)
        {
            return BadRequest($"Not Found Categroy With Id: {Id}");
        }
        await _categoryService.DeleteCategoryAsync(Id);
        await _unitOfWork.CompleteAsync();
        return Ok("Delete Complete");


    }

}








