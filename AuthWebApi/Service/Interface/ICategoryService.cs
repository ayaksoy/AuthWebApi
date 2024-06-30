using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthWebApi.Model;

namespace AuthWebApi.Service.Interface
{
    public interface ICategoryService
    {
        public Task<string> AddAsync(Category category);
        public Task<Category> GetByIdAsync(int id);
        public Task<List<Category>> GetAllAsync();
        public Task<string> UpdateAsync(Category category);
        public Task<string> DeleteAsync(int id);
    }
}