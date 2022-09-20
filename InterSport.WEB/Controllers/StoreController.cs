using InterSport.Domain.Entities;
using InterSport.Domain.Interfaces.Services;
using InterSport.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace InterSport.WEB.Controllers
{
    public class StoreController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        public StoreController(ICategoryService categoryService, IBrandService brandService, IProductService productService)
        {
            _categoryService = categoryService;
            _brandService = brandService;
            _productService = productService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Store()
        {
            return View("~/Views/Store/Store.cshtml");
        }
        public ActionResult GetListCategories()
        {
            var categories = _categoryService.GetListCategies();
            return PartialView("~/Views/Store/ListCategories.cshtml", categories);
        }
        public ActionResult GetListBrands(int categoryId)
        {
            List<Brand> brands = new List<Brand>();

            if (categoryId == 0) brands = _brandService.GetListBrands();
            else brands = _brandService.GetListBrandsByCategory(categoryId);

            return PartialView("~/Views/Store/ListBrands.cshtml", brands);
        }
        public ActionResult GetFilteredProducts(int categoryId, int brandId)
        {
            if (Session["Products"] == null)
            {
                Session["Products"] = _productService.GetListProducts();
            }
            var products = Session["Products"] as List<ProductViewModel>;

            if (categoryId > 0)
            {
                products = products.Where(p => p.CategoryId == categoryId).ToList();
            }
            if (brandId > 0)
            {
                products = products.Where(p => p.BrandId == brandId).ToList();
            }
            foreach (var product in products)
            {
                product.Base64 = _productService.ConvertBase64(Path.Combine(product.ImagePath, product.ImageName));
                product.Extension = Path.GetExtension(product.Name);
            }
            return PartialView("~/Views/Store/ListProducts.cshtml", products);
        }
    }
}