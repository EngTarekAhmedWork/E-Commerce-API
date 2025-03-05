using E_Commerce_API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Infrastructure.Data
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderdetails { get; set; }

        public DbSet<User> users { get; set; }

    }
}
