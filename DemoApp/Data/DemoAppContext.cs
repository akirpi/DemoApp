using DemoApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DemoApp.Data
{
    public class DemoAppContext : IdentityDbContext<StoreUser>
    {
        public DemoAppContext(DbContextOptions<DemoAppContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DemoApp.ViewModels.ProductViewModel> ProductViewModel { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<DemoApp.ViewModels.MessageViewModel> MessageViewModel { get; set; }
    }
}
