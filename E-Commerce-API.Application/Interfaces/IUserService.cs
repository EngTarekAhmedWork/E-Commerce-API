using E_Commerce_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task RegisterAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task DeleteAsync(int id);

        Task UpdateAsync(int Id, User user);

        Task LoginAsync(User user);
    }
}
