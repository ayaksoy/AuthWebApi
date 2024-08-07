using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthWebApi.Model;

namespace AuthWebApi.Service.Interface
{
    public interface IProductService
    {
        public Task<string> AddAsync(Product product);
        public Task<Product> GetByIdAsync(int id);
        public Task<List<Product>> GetAllAsync();
        public Task<List<Product>> GetAllCategoryProductAsync(int id);
        public Task<string> UpdateAsync(Product product);
        public Task<string> DeleteAsync(int id);
    }
}