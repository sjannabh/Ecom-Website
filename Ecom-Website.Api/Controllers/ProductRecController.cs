using Ecom_Website.Api.Repository.IRepository;
using Ecom_Website.Entity.Models.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_Website.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRecController : ControllerBase
    {
        private readonly IProductRecRepository _productRec;

        public ProductRecController(IProductRecRepository productRec)
        {
            _productRec = productRec;
        }

        //create
        [HttpPost("create")]
        public async Task Create(PopularRecommendation popular)
        {
            await _productRec.Create(popular);
        }

        //GetAll
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllResults()
        {
            var resp = await _productRec.GetAll();
            return new JsonResult(resp);
        }

        //get by id
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var resp =await _productRec.GetById(id);
            return new JsonResult(resp);
        }

        //update
        [HttpPut("update")]

        public async Task<IActionResult> update(string id, PopularRecommendation popRec)
        {
            var item = await _productRec.GetById(id);
            popRec.Id  = item.Id;
            await _productRec.Update(id, popRec);
            return NoContent();
        }

        //Delete
        [HttpDelete("delete")]
        public async Task<IActionResult> delete(string id)
        {
            await _productRec.Delete(id);   
            return NoContent();
        }
    }
}
