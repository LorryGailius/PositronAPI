using PositronAPI.Models.Customer;

namespace PositronAPI.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(long customerId);
        Task<Customer> EditCustomer(CustomerUpdateDTO customer, long customerId);
        Task<Customer> GetCustomer(long customerId);
        Task<List<Customer>> GetCustomers(int top = 10, int skip = 0);
    }
}
