using Akanay.Entities.Models;
using Akanay.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Akanay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private  IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //[Authorize(Roles ="Product.List")]
        public IActionResult GetAll()
        {
            
            var result = _productService.GetAll();
            if(result.IsSuccess )
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.IsSuccess)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPut]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpGet("[action]")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.IsSuccess)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }


        [HttpPost("transaction")]
        public IActionResult TransactionTest(Product product)
        {
            var result = _productService.TransactionalOperation(product);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }





    }
}
