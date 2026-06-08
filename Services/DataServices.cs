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
    public class DataServices
    {
        public List<Product> GetProducts() { using var db = new AppDbContext(); return db.Product.ToList(); }
        public void AddProduct(Product p) { using var db = new AppDbContext(); db.Product.Add(p); db.SaveChanges(); }
        public void UpdateProduct(Product p) { using var db = new AppDbContext(); db.Product.Update(p); db.SaveChanges(); }
        public void DeleteProduct(int id) { using var db = new AppDbContext(); var p = db.Product.Find(id); if (p != null) db.Product.Remove(p); db.SaveChanges(); }
        
        public List<Order> GetOrders() { using var db = new AppDbContext(); return db.Order.Include(p => p.Address).Include(p => p.User).ToList(); }
        public void AddOrder(Order p) { using var db = new AppDbContext(); db.Order.Add(p); db.SaveChanges(); }
        public void UpdateOrder(Order p) { using var db = new AppDbContext(); db.Order.Update(p); db.SaveChanges(); }
        public void DeleteOrder(int id) { using var db = new AppDbContext(); var p = db.Order.Find(id); if (p != null) db.Order.Remove(p); db.SaveChanges(); }

        public List<User> GetUser() { using var db = new AppDbContext(); return db.User.ToList(); }
        public List<Address> GetAddress() { using var db = new AppDbContext(); return db.Address.ToList(); }
        public User Authenticate(string login, string password)
        {
            using var db = new AppDbContext();
            return db.User.FirstOrDefault(p => p.Login == login && p.Password == password);
        }
    }
}
