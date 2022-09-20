using InterSport.Domain.Entities;
using System.Collections.Generic;

namespace InterSport.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        bool DeleteCustomerById(int customerId);
        Customer GetCustomerById(int customerId);
        List<Customer> GetListCustomers();
        bool UpdateCustomer(Customer customer);
    }
}
