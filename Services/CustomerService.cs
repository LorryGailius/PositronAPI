using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Customer;

namespace PositronAPI.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        // Add a customer
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            Customer newCustomer = new Customer
            {
                Name = customer.Name,
                Email = customer.Email
            };

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer;
        }

        // Remove a customer
        public async Task<Customer> DeleteCustomer(long customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                return null;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        // Edit a customer
        public async Task<Customer> EditCustomer(Customer customer, long customerId)
        {
            var existingCustomer = await _context.Customers.FindAsync(customerId);
            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;

            await _context.SaveChangesAsync();

            return existingCustomer;
        }

        // Get a customer
        public async Task<Customer> GetCustomer(long customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        // Get all customers
        public async Task<List<Customer>> GetCustomers(int top = 10, int skip = 0)
        {
            return await _context.Customers.Skip(skip).Take(top).ToListAsync();
        }

    }
}
