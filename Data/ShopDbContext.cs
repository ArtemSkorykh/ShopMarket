using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Models;
using ShopMarket.Models.ViewModels.Account;
using ShopMarket.Models.DTOs.Users;

namespace ShopMarket.Data
{
    public class ShopDbContext:IdentityDbContext<ShopUser>
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) {
        Database.EnsureCreated();
        }             
        public DbSet<ShopMarket.Models.DTOs.Users.EditUserDTO> EditUserDTO { get; set; } = default!;
        public DbSet<ShopMarket.Models.DTOs.Users.ChangePasswordDTO> ChangePasswordDTO { get; set; } = default!;
       

    }
}
