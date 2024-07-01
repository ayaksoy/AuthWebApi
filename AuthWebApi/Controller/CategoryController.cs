using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using AuthWebApi.Model;
using AuthWebApi.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        { 
            _categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryService.GetAllAsync();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await _categoryService.GetByIdAsync(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<string> Post([FromBody] Category category)
        {
            var result=await _categoryService.AddAsync(category);

            return result;
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] Category category)
        {
            category.Id = id;
            return await _categoryService.UpdateAsync(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await _categoryService.DeleteAsync(id);
        }
    }
}
