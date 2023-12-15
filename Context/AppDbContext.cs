using Microsoft.EntityFrameworkCore;
using PositronAPI.Models.Coupon;
using PositronAPI.Models.Customer;
using PositronAPI.Models.Item;
using PositronAPI.Models.LoyaltyCard;
using PositronAPI.Models.Employee;

namespace PositronAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

    }
}
