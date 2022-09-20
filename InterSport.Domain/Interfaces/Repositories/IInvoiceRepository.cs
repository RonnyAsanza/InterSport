using InterSport.Domain.Entities;
using InterSport.Domain.Models;
using System;
using System.Collections.Generic;


namespace InterSport.Domain.Interfaces.Repositories
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetInvoices(DateTime startDate, DateTime endDate, int transaction);
        SalesReport GetReport();
        List<InvoiceViewModel> GetInvoicesViewModel(DateTime startDate, DateTime endDate, int transaction);
    }
}
