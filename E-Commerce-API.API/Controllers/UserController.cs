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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync() 
        {
            return Ok(await _unitOfWork.User.GetAllAsync());
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(UserDto userDto) 
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.User.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return Ok(user);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto userDto) 
        {
            var user = new User();
           
            if (userDto.Email != user.Email && userDto.Password != user.Password) 
            {
                return BadRequest("Email Or Password Incorrect");
            }
             
            return Ok($"Login Sccussful! {userDto.Email}");
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> DeleteAsync(int Id) 
        {
            var user = await _unitOfWork.User.GetFirstOrDefaultAsync(x => x.Id == Id);
            if (user == null) 
            {
                return BadRequest($"Not Found User With ID: {Id}");
            }
            await _unitOfWork.User.DeleteAsync(user);
            await _unitOfWork.CompleteAsync();
            return Ok("Deleted User Done!");    
        }
    }

}



