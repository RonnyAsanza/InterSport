using InterSport.Domain.Interfaces.Services;
using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterSport.WEB.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCustomerList()
        {
            try
            {
                var xcustomers = Session["Customers"] as List<Customer>;

                var customers = _customerService.GetListCustomers();
                return View("~/Views/Product/Index.cshtml", customers);

            }
            catch
            {
                return View();
            }
        }
    }
}