using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestSeniorBackendWebDeveloper.Models;
using TestSeniorBackendWebDeveloper.Services;

namespace TestSeniorBackendWebDeveloper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductViewModel>>> Get() =>
            await _productService.Get();

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ProductViewModel> Get(Guid id)
        {
            var product = await _productService.Get(id);

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(ProductAddUpdateModel model)
        {
            return await _productService.Create(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ProductAddUpdateModel model)
        {
            await _productService.Update(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.Remove(id);

            return Ok();
        }
    }
}
