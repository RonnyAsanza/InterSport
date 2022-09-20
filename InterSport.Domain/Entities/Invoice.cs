using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterSport.Domain.Entities
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public int Items { get; set; }
        public decimal Total { get; set; }
        public string Transaction { get; set; }
        public DateTime DateInvoice { get; set; }
    }
}
