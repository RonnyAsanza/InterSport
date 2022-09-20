using InterSport.Domain.Entities;
using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Interfaces.Services;
using InterSport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invocieRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invocieRepository = invoiceRepository;
        }
        public List<InvoiceViewModel> GetInvoicesViewModel(string startDate, string endDate, string transaction)
        {
            int invoiceId;
            if (string.IsNullOrWhiteSpace(transaction) || string.IsNullOrEmpty(transaction)) invoiceId = 0;
            else invoiceId = Convert.ToInt32(transaction);

            DateTime start = Convert.ToDateTime(startDate);
            DateTime end = Convert.ToDateTime(endDate);

            return _invocieRepository.GetInvoicesViewModel(start, end, invoiceId);
        }
        public List<Invoice> GetInvoices(string startDate, string endDate, string transaction)
        {
            int invoiceId;
            if (string.IsNullOrWhiteSpace(transaction) || string.IsNullOrEmpty(transaction)) invoiceId = 0;
            else invoiceId = Convert.ToInt32(transaction);
            DateTime start = Convert.ToDateTime(startDate);
            DateTime end = Convert.ToDateTime(endDate);

            return _invocieRepository.GetInvoices(start, end, invoiceId);
        }
        public SalesReport GetReport()
        {
           return _invocieRepository.GetReport();
        }
    }
}
