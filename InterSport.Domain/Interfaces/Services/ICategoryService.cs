using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        List<Category> GetListCategies();
        bool DeleteCategory(int categoryId);
        bool EditCategory(Category category);
        int CreateCategory(Category category);
        Category GetCategoryById(int categoryId);
    }
}
