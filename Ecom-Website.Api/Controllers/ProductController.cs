using Ecom_Website.Api.Repository.IRepository;
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
            return new JsonResult(products);
        }

        // Get product by Id
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productRepository.GetProductById(id);
            return new JsonResult(product);
        }
    }
}
