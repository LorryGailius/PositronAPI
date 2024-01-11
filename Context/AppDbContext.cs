using Microsoft.EntityFrameworkCore;
using PositronAPI.Models.Coupon;
using PositronAPI.Models.Customer;
using PositronAPI.Models.Item;
using PositronAPI.Models.LoyaltyCard;
using PositronAPI.Models.Employee;
using PositronAPI.Models.Department;
using PositronAPI.Models.Schedule;
using PositronAPI.Models.Order;
using PositronAPI.Models.Payment;

namespace PositronAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        


        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<Payment> Payments { get; set; }


        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
