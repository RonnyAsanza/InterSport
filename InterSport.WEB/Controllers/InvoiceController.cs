using ClosedXML.Excel;
using InterSport.Domain.Entities;
using InterSport.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterSport.WEB.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetInvoices(string startDate, string endDate, string transaction)
        {       
            var invoices = _invoiceService.GetInvoices(startDate, endDate, transaction);
            return PartialView("~/Views/Invoice/GetInvoices.cshtml", invoices);
        }
        public ActionResult GetInvoicesViewModel(string startDate, string endDate, string transaction)
        {
            var invoices = _invoiceService.GetInvoicesViewModel(startDate, endDate, transaction);
            return PartialView("~/Views/Invoice/GetInvoices.cshtml", invoices);
        }

        public ActionResult GetReport()
        {
            var report = _invoiceService.GetReport();
            return PartialView("~/Views/Invoice/GetReport.cshtml", report);
        }

        public FileResult ExportInvoice(string startDate, string endDate, string transaction)
        {
            var invoiceDetail = _invoiceService.GetInvoices(startDate, endDate, transaction);

            DataTable dataTable = new DataTable();
            dataTable.Locale = new System.Globalization.CultureInfo("es-EC");
            dataTable.Columns.Add("InvoiceId", typeof(string));
            dataTable.Columns.Add("DateInvoice", typeof(string));
            dataTable.Columns.Add("Customer", typeof(string));
            dataTable.Columns.Add("Items", typeof(int));
            dataTable.Columns.Add("Total", typeof(decimal));

            foreach(var item in invoiceDetail)
            {
                dataTable.Rows.Add(new object[] {
                    item.InvoiceId,
                    item.DateInvoice,
                    item.CustomerId,
                    item.Items,
                    item.Total
                });
            }
            //foreach (var item in invoiceDetail)
            //{
            //    dataTable.Rows.Add(new object[] {
            //        item.InvoiceId,
            //        item.DateInvoice,
            //        item.Customer,
            //        item.Items,
            //        item.Total
            //    });
            //}
            dataTable.TableName = "Invoice";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportSale" + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }
        public FileResult ExportDetailInvoice(string startDate, string endDate, string transaction)
        {
            if(string.IsNullOrEmpty(transaction) || string.IsNullOrWhiteSpace(transaction)) return null;
            var invoiceDetail = _invoiceService.GetInvoicesViewModel(startDate, endDate, transaction);

            DataTable dataTable = new DataTable();
            dataTable.Locale = new System.Globalization.CultureInfo("es-EC");
            dataTable.Columns.Add("DateInvoice", typeof(string));
            dataTable.Columns.Add("Client", typeof(string));
            dataTable.Columns.Add("Product", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Price", typeof(decimal));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("SubTotal", typeof(decimal));
            dataTable.Columns.Add("Total", typeof(decimal));
            dataTable.Columns.Add("Items", typeof(int));
            dataTable.Columns.Add("TransactionID", typeof(string));

            foreach (var item in invoiceDetail)
            {
                dataTable.Rows.Add(new object[] {
                    item.DateInvoice,
                    item.Client,
                    item.Product,
                    item.Description,
                    item.Price,
                    item.Quantity,
                    item.SubTotal,
                    item.Total,
                    item.Items,
                    item.Transaction
                });
            }
            dataTable.TableName = "Detail";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportSale" + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }
    }
}