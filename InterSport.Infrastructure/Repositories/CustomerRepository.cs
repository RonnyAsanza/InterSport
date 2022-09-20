using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Entities;
using InterSport.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace InterSport.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool DeleteCustomerById(int customerId)
        {
            try
            {
                using (var context = new InterSportContext())
                {
                    var response = context.Database.ExecuteSqlCommand("delete from Customers where CustomerId = " + customerId);

                    if (response > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public Customer GetCustomerById(int customerId)
        {
            try
            {
                using (var context = new InterSportContext())
                {
                    var customer = context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                    return customer;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Customer> GetListCustomers()
        {
            try
            {
                using (var context = new InterSportContext())
                {
                    var listCustomer = context.Customers.ToList();
                    return listCustomer;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                using (var context = new InterSportContext())
                {
                    var query = (from a in context.Customers
                                 where a.CustomerId == customer.CustomerId
                                 select a).FirstOrDefault();
                    if (query != null)
                    {
                        query.FirstName = customer.FirstName;
                        query.LastName = customer.LastName;
                        query.Email = customer.Email;
                        query.Password = customer.Password;
                        query.RestorePassword = customer.RestorePassword;
                        query.Phone = customer.Phone;
                        query.IsActive = customer.IsActive;

                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
