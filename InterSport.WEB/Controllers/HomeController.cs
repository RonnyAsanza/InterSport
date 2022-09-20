using InterSport.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterSport.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        public HomeController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public ActionResult Index()
        {
            var invoices = _invoiceService.GetReport();
            return View(invoices);
        }
        public ActionResult SalesReport()
        {
            return View();
        }
    }
}