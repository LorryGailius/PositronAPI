using Microsoft.EntityFrameworkCore;
using PositronAPI.Models;

namespace PositronAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        DbSet<Customer> customers { get; set; }

        DbSet<Coupon> coupons { get; set; }

        DbSet<Item> items { get; set; }

        DbSet<LoyaltyCard> loyaltyCards { get; set; }

    }
}
