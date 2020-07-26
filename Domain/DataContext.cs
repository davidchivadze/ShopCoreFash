using Microsoft.EntityFrameworkCore;

using Models.AdminPanel.Database.Accounting;
using Models.AdminPanel.Database.Products;
using System;

namespace Database
{
    public class DataContext : DbContext
    {

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1NDTU6P\\SQLEXPRESS;Database=Shop;Integrated Security=True");
        }


        public DbSet<User> User { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductSizes> ProductSizes { get; set; }
    }
}
