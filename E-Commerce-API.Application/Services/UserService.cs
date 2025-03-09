using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _unitOfWork.User.GetFirstOrDefaultAsync(x => x.Id == id);
            await _unitOfWork.User.DeleteAsync(result);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.User.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.User.GetFirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        #region Old Login
        //public async Task LoginAsync(User user)
        //{
        //    var LoginUser = await _unitOfWork.User.GetFirstOrDefaultAsync(x=> x.UserName == user.UserName && x.Password == user.Password);
        //    if (LoginUser.UserName != user.UserName && LoginUser.Password != user.Password) 
        //    {
        //        Console.Write("User Or Password Incorrect");
        //    }

        //    Console.Write("Welecom To Our Store");
        //}
        #endregion

        // New Login
        public async Task<string> LoginAsync(string UserName, string Password)
        {
            var LoginUser = await _unitOfWork.User.GetFirstOrDefaultAsync(x => x.UserName == UserName);
            if (LoginUser != null)
            {
                if ( LoginUser.Password == Password)
                {
                    // Login logic must added here
                    return "User loged in successfully";
                }
                return "Password is incorrect";
            }
            return "This user does not exist";
        }

        public async Task RegisterAsync(User user)
        {
            await _unitOfWork.User.AddAsync(user);
        }

        public async Task UpdateAsync(int Id, User user)
        {
            var result = await _unitOfWork.User.GetFirstOrDefaultAsync(x => x.Id == Id);
            result.UserName = user.UserName;
            result.Email = user.Email;
            result.Password = user.Password;
            result.PhoneNumber = user.PhoneNumber;
            result.BirthDay = user.BirthDay;
            result.Address = user.Address;
            result.Role = user.Role;
            await _unitOfWork.User.UpdateAsync(result);
        }
    }
}
