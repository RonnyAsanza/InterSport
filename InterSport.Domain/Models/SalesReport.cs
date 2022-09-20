using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Models
{
    public class SalesReport
    {
        public int NumSales { get; set; }
        public List<NumCustomer> NumCustomers {get; set;}
        public List<NumProduct> NumProducts { get; set; }

    }
    public class NumCustomer
    {
        public int CustomerId { get; set; }
        public int NumPurchases { get; set; }
    }
    public class NumProduct
    {
        public int ProductId { get; set; }
        public int NumSales { get; set; }
    }
}
