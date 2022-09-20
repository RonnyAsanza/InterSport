using InterSport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        int CreateCategory(Category category);
        Category GetCategoryById(int categoryId);
        bool DeleteCategory(int categoryId);
        bool EditCategory(Category category);
        List<Category> GetListCategies();
    }
}
