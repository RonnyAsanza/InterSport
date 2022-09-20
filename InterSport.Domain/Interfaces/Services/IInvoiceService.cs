using InterSport.Domain.Entities;
using InterSport.Domain.Models;
using System;
using System.Collections.Generic;

namespace InterSport.Domain.Interfaces.Services
{
    public interface IInvoiceService
    {
        List<Invoice> GetInvoices(string startDate, string endDate, string transaction);
        SalesReport GetReport();
        List<InvoiceViewModel> GetInvoicesViewModel(string startDate, string endDate, string transaction);

    }
}
