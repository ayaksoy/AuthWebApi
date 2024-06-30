using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthWebApi.Data;
using AuthWebApi.Model;
using AuthWebApi.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuthWebApi.Service.Model
{
    public class CategoryService : ICategoryService
    {
        ApplicationDbContext db;
        public CategoryService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public Task<string> AddAsync(Category category)
        {
            var result = "";
            if (category != null)
            {
                db.Category.AddAsync(category);
                db.SaveChanges();
                result = "Category Added Successful";
            }
            else
            {
                result = "Category Added Error";
            }
            return Task.FromResult(result);
        }

        public Task<string> DeleteAsync(int id)
        {
            var result = "";
            var category = db.Category.FirstOrDefault(c => c.Id == id && !c.IsDelete);

            if (category != null)
            {
                category.IsDelete = true;
                db.SaveChanges();
                result = "Category Deleted Successful";
            }
            else
            {
                result = "Not Found Category";
            }
            return Task.FromResult(result);
        }

        public Task<List<Category>> GetAllAsync()
        {
            var categoryList = db.Category.Where(c => !c.IsDelete).ToListAsync();
            return categoryList;
        }

        public Task<Category> GetByIdAsync(int id)
        {
            var category = db.Category.FirstOrDefaultAsync(c => c.Id == id && !c.IsDelete);
            return category;
        }

        public Task<string> UpdateAsync(Category category)
        {
            var updateCategory = db.Category.FirstOrDefault(c => c.Id == category.Id && !c.IsDelete);
            var result = "";
            if (updateCategory != null)
            {
                updateCategory.Name = category.Name;
                updateCategory.Description = category.Description;
                updateCategory.IsStatus = category.IsStatus;

                db.SaveChanges();
                result = "Category Update Successful";
            }
            else
            {
                result = "Category Not Found";
            }
            return Task.FromResult(result);
        }
    }
}
