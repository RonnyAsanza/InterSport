using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Interfaces.Services;
using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public int CreateCategory(Category category)
        {
            return _categoryRepository.CreateCategory(category);
        }

        public bool DeleteCategory(int categoryId)
        {
            return _categoryRepository.DeleteCategory(categoryId);
        }

        public bool EditCategory(Category category)
        {
            _categoryRepository.EditCategory(category);
            return true;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public List<Category> GetListCategies()
        {
            return _categoryRepository.GetListCategies();
        }
    }
}
