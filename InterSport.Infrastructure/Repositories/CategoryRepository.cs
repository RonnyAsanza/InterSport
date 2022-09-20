using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Entities;
using InterSport.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterSport.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public int CreateCategory(Category category)
        {

            using (var context = new InterSportContext())
            {
                context.Categorys.Add(category);
                context.SaveChanges();
                return category.CategoryId;
            }

        }
        public Category GetCategoryById(int categoryId)
        {
            using (var context = new InterSportContext())
            {
                return context.Categorys.FirstOrDefault(c => c.CategoryId == categoryId);
            }

        }
        public bool DeleteCategory(int categoryId)
        {

            using (var context = new InterSportContext())
            {
                var response = context.Database.ExecuteSqlCommand("delete top(1) from Categorys where CategoryId = " + categoryId);
                if (response > 0) return true;
                return false;
            }

        }
        public bool EditCategory(Category category)
        {
            using (var context = new InterSportContext())
            {
                var query = (from c in context.Categorys
                             where c.CategoryId == category.CategoryId
                             select c).FirstOrDefault();
                if (query != null)
                {
                    query.Description = category.Description;
                    query.IsActive = category.IsActive;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<Category> GetListCategies()
        {
            using (var context = new InterSportContext())
            {
                var categories = context.Categorys.ToList();
                return categories;
            }
        }
    }
}

