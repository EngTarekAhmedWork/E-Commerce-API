using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using E_Commerce_API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Infrastructure.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContex context) : base(context)
        {
        }
    }
}
