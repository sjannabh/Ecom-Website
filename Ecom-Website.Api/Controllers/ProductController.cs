using Ecom_Website.Api.Repository.IRepository;
using Ecom_Website.Entity.Models.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_Website.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        //Get all products
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProducts() 
        {
            var products = await _productRepository.GetAll();
            if (products == null) 
            {
                return NotFound();
            }
            return new JsonResult(products);
        }

        // Get product by Id
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) 
            {
                return NotFound();
            }
            return new JsonResult(product);
        }

        //create a new product
        [HttpPost("create")]
        public async Task CreateProduct(Product prod)
        {
            
            await _productRepository.Create(prod);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(string productid, Product prod)
        {
            var product = await _productRepository.GetProductById(productid);

            if(product == null)
            {
                return NotFound();
            }

            prod.Id = product.Id;

            await _productRepository.Update(productid, prod);
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProduct(string productid)
        {
            var prod = await _productRepository.GetProductById(productid);

            if (prod == null)
            {
                return NotFound();
            }
            await _productRepository.Delete(productid);
            return NoContent();
        }
    }
}
