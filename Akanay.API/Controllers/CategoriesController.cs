using Akanay.Entities.Models;
using Akanay.Service.Interfaces;
using Akanay.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akanay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.IsSuccess)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var result = _categoryService.GetById(id);
            if (result.IsSuccess)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Category   category)
        {
            var result = _categoryService.Delete(category);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }







    }
}
