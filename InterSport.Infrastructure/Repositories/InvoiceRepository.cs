using InterSport.Domain.Entities;
using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Models;
using InterSport.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public List<Invoice> GetInvoices(DateTime startDate, DateTime endDate, int transaction)
        {
            using (var context = new InterSportContext())
            {
                var invoices = context.Invoices.ToList().Where(x => x.DateInvoice >= startDate && x.DateInvoice <= endDate).ToList();
                if (transaction == 0) return invoices;
                return invoices.Where(x => x.InvoiceId == transaction).ToList();
            }
        }
        public SalesReport GetReport()
        {
            SalesReport sales = new SalesReport();

            using (var context = new InterSportContext())
            {
                var parameter = new SqlParameter { ParameterName = "@s_numInvoices", DbType = DbType.Int32, Direction = ParameterDirection.Output };

                var cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "[dbo].[SP_SalesReport]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(parameter);
                context.Database.Connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    sales.NumCustomers = ((IObjectContextAdapter)context)
                   .ObjectContext
                   .Translate<NumCustomer>(reader)
                   .ToList();

                    reader.NextResult();

                    sales.NumProducts = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<NumProduct>(reader)
                        .ToList();

                    context.Database.Connection.Close();
                    sales.NumSales = (int)parameter.Value;

                }
                return sales;


                ////context.Database.ExecuteSqlCommand("exec SP_SalesReport @s_numInvoices out", parameter);
                //List<SalesReport> salesReports = new List<SalesReport>();
                //SalesReport sales = new SalesReport();

                //int numInvoices = (int)parameter[0].Value;
                //var numCustomers = (List<NumCustomer>)parameter[1].Value;
                //var numProducts = (List<NumProduct>)parameter[2].Value;


                //sales.Sales = numInvoices;
                //sales.numCustomers = numCustomers;
                //sales.numProducts = numProducts;
                //salesReports.Add(sales);
                //return salesReports;
            }
        }
        public List<InvoiceViewModel> GetInvoicesViewModel(DateTime startDate, DateTime endDate, int transaction)
        {
            using (var context = new InterSportContext())
            {
                var invoiceViewModel = (from i in context.Invoices
                                        join c in context.Customers on i.CustomerId equals c.CustomerId
                                        join d in context.InvoicesDetails on i.InvoiceId equals d.InvoiceId
                                        join p in context.Products on d.ProductId equals p.ProductId
                                        where EntityFunctions.TruncateTime(i.DateInvoice) >= startDate.Date &&
                                        EntityFunctions.TruncateTime(i.DateInvoice) <= endDate.Date
                                        && ((transaction == 0) || (i.InvoiceId == transaction))
                                        select new InvoiceViewModel
                                        {
                                            InvoiceId = i.InvoiceId,
                                            Client = c.FirstName + " " + c.LastName,
                                            Product = p.Name,
                                            Description = p.Description,
                                            Price = p.Price,
                                            Quantity = d.Quantity,
                                            SubTotal = d.SubTotal,
                                            Total = i.Total,
                                            Transaction = i.Transaction,
                                            DateInvoice = i.DateInvoice

                                        }).ToList();
                return invoiceViewModel;
            }
        }
    }
}
