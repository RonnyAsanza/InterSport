using InterSport.Domain.Entities;
using System.Collections.Generic;

namespace InterSport.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetListCustomers();
        bool UpdateCustomer(Customer customer);
        Customer GetCustomerById(int customerId);
        bool DeleteCustomerById(int customerId);
    }
}
