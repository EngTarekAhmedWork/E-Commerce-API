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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork , IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync() 
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync(UserDto userDto) 
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.RegisterAsync(user);
            await _unitOfWork.CompleteAsync();
            return Ok(user);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto userDto) 
        {
            //var user = new User();
           
            //if (userDto.Email != user.Email && userDto.Password != user.Password) 
            //{
            //    return BadRequest("Email Or Password Incorrect");
            //}
             
            //return Ok($"Login Sccussful! {userDto.Email}");


            var res = await _userService.LoginAsync(userDto.Email, userDto.Password);
            return Ok(res);
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> DeleteAsync(int Id) 
        {
            var user = await _userService.GetByIdAsync(Id);
            if (user == null) 
            {
                return BadRequest($"Not Found User With ID: {Id}");
            }
            await _userService.DeleteAsync(Id);
            await _unitOfWork.CompleteAsync();
            return Ok("Deleted User Done!");    
        }
    }

}



