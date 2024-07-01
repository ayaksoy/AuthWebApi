using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using AuthWebApi.Model;
using AuthWebApi.Service.Interface;
using AuthWebApi.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;   

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }    
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetAllAsync();
        }

        // Get api/Product/categoryId?cid=5
        [HttpGet("categoryId")]
        public async Task<IEnumerable<Product>> Get(string cid)
        {
            return await _productService.GetAllCategoryProductAsync(Convert.ToInt32(cid));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<string> Post([FromBody] Product product)
        {
            var result = await _productService.AddAsync(product);

            return result;
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] Product product)
        {
            product.Id = id;
            return await _productService.UpdateAsync(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await _productService.DeleteAsync(id);
        }
    }
}
