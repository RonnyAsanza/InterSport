using InterSport.Domain.Interfaces.Services;
using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterSport.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListCategories()
        {
            return ViewResponse();
        }
        public ActionResult DeleteCategory(int categoryId)
        {
            var delete = _categoryService.DeleteCategory(categoryId);
            if (delete) return ViewResponse();
            return null;
        }
        public ActionResult SaveCategory(Category category)
        {
            if(category.CategoryId > 0)
            {
                _categoryService.EditCategory(category);
            }
            else
            {
                _categoryService.CreateCategory(category);
            }
            return ViewResponse();
        }
        public PartialViewResult ViewResponse()
        {
            var categorys = _categoryService.GetListCategies();
            return PartialView("~/Views/Category/ListCategories.cshtml", categorys);
        }
    }
}