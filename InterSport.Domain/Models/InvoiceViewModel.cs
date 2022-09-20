using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Models
{
    public class InvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string Transaction { get; set; }
        public DateTime DateInvoice { get; set; }
        public int Items { get; set; }
    }
}
