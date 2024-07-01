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
    public class ProductService : IProductService
    {

        ApplicationDbContext db;
        public ProductService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public Task<string> AddAsync(Product product)
        {
            var result = "";
            if (product != null)
            {
                db.Product.AddAsync(product);
                db.SaveChanges();
                result = "Product Added Successful";
            }
            else
            {
                result = "Product Added Error";
            }
            return Task.FromResult(result);
        }

        public Task<string> DeleteAsync(int id)
        {
            var result = "";
            var product = db.Product.FirstOrDefault(c => c.Id == id && !c.IsDelete);

            if (product != null)
            {
                product.IsDelete = true;
                db.SaveChanges();
                result = "Product Deleted Successful";
            }
            else
            {
                result = "Not Found Product";
            }
            return Task.FromResult(result);
        }

        public Task<List<Product>> GetAllAsync()
        {
            var productList = db.Product.Where(c => !c.IsDelete).ToListAsync();
            return productList;
        }

        public Task<List<Product>> GetAllCategoryProductAsync(int id)
        {
            var productList = db.Product.Where(c => !c.IsDelete && c.CategoryId == id).ToListAsync();
            return productList;
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var product = db.Product.FirstOrDefaultAsync(c => c.Id == id && !c.IsDelete);
            return product;
        }

        public Task<string> UpdateAsync(Product product)
        {
            var updateProduct = db.Product.FirstOrDefault(c => c.Id == product.Id && !c.IsDelete);
            var result = "";
            if (updateProduct != null)
            {
                updateProduct.Name = product.Name;
                updateProduct.Description = product.Description;
                updateProduct.IsStatus = product.IsStatus;
                updateProduct.Price = product.Price;
                updateProduct.Stock = product.Stock;
                updateProduct.CategoryId = product.CategoryId;

                db.SaveChanges();
                result = "Product Update Successful";
            }
            else
            {
                result = "Product Not Found";
            }
            return Task.FromResult(result);
        }
    }
}
