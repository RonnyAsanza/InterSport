using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Interfaces.Services;
using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository _customerRepository)
        {
            customerRepository = _customerRepository;
        }
        public bool DeleteCustomerById(int customerId)
        {
            return customerRepository.DeleteCustomerById(customerId);
        }

        public Customer GetCustomerById(int customerId)
        {
            return customerRepository.GetCustomerById(customerId);
        }

        public List<Customer> GetListCustomers()
        {
            return customerRepository.GetListCustomers();
        }

        public bool UpdateCustomer(Customer customer)
        {
            return customerRepository.UpdateCustomer(customer);
        }
    }
}
