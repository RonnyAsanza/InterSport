using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Interfaces.Services;
using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterSport.WEB.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListBrands()
        {
            return ViewResponse();
        }
        public PartialViewResult ViewResponse()
        {
            var brands = _brandService.GetListBrands();
            return PartialView("~/Views/Brand/ListBrands.cshtml", brands);
        }
        public ActionResult DeleteBrand(int brandId)
        {
            var delete = _brandService.DeleteBrand(brandId);
            if (delete) return ViewResponse();
            return null;
        }
        public ActionResult SaveBrand(Brand brand)
        {
            if (brand.BrandId > 0)
            {
                _brandService.EditBrand(brand);
            }
            else
            {
                _brandService.CreateBrand(brand);
            }
            return ViewResponse();
        }
    }
}