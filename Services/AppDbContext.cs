using ex.Models;
using ex.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex.Services
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conectionString = "server=localhost;port=3306;user=root;password=root;database=ex;";
            optionsBuilder.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString));
        }
        public DbSet<Address> Address { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Address>().ToTable("address");
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Order>().ToTable("order");
        }
    }
}