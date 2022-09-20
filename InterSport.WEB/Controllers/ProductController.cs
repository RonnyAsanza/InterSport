using InterSport.Domain.Entities;
using InterSport.Domain.Interfaces.Services;
using InterSport.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterSport.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _brandService = brandService;
            _categoryService = categoryService;
            _productService = productService;
        }
        public ActionResult Index()
        {
            var brands = _brandService.GetListBrands();
            var categories = _categoryService.GetListCategies();
            ViewBag.cartegories = categories;
            return View(brands);
        }
        public PartialViewResult GetViewListProduts()
        {
            var products = _productService.GetListProducts();
            return PartialView("~/Views/Product/ListProducts.cshtml", products);
        }
        public ActionResult DeleteProduct(int productId)
        {
            var delete = _productService.DeleteProduct(productId);
            if (delete) return GetViewListProduts();
            return null;
        }
        public ActionResult SaveProduct(string productString, HttpPostedFileBase fileImage)
        {
            ProductViewModel product = new ProductViewModel();
            product = JsonConvert.DeserializeObject<ProductViewModel>(productString);

            if (product.ProductId > 0)
                _productService.EditProduct(product);           
            else
            {
                product.DateRegistration = DateTime.Now;
                product.ProductId = _productService.CreateProduct(product);
            }

            if (fileImage != null)
            {
                string pathImage = ConfigurationManager.AppSettings["ServerImage"];
                string extensionImage = Path.GetExtension(fileImage.FileName);
                string nameImage = string.Concat(product.ProductId.ToString(), extensionImage);
                fileImage.SaveAs(Path.Combine(pathImage, nameImage));

                Image img = new Image();
                img.ImageName = nameImage;
                img.ImagePath = pathImage;
                img.Extension = extensionImage;
                img.Base64 = "base64";

                var imageId = _productService.SaveImage(img);
                product.ImageId = imageId;
                _productService.EditProduct(product);
            }
            return GetViewListProduts();
        }
        public JsonResult ImageProduct(string imagePath, string imageName)
        {
            try
            {
                string txtBase64 = _productService.ConvertBase64(Path.Combine(imagePath, imageName));
                return Json(new
                {
                    txtBase64 = txtBase64,
                    extension = Path.GetExtension(imageName),

                    JsonRequestBehavior.AllowGet
                });
            }
            catch
            {
                return Json(new{ img = "not image" });
            }
        }
    }
}