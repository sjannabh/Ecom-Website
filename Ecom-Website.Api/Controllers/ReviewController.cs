using Ecom_Website.DataAccess.Models.Mongo;
using Ecom_Website.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_Website.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        //create review
        [HttpPost("create")]
        public async Task Create(Review review)
        {
            await _reviewRepository.Create(review);
        }

        //Get all reviews
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(int count = 10)
        {
            var rev = await _reviewRepository.GetAll(count);
            if (rev == null)
            {
                return NotFound();
            }
            return new JsonResult(rev);
        }

        //Get by ProductId
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var rev = await _reviewRepository.GetById(id);
            if (rev == null)
            {
                return NotFound();
            }
            return new JsonResult(rev);
        }

        [HttpGet("getByProductId/{productId}")]
        public async Task<IActionResult> GetByProductId(string productId)
        {
            var response = await _reviewRepository.GetReviewByProductId(productId);
            return new JsonResult(response);
        }

        //Update review
        [HttpPut("update")]
        public async Task<IActionResult> Update(string id, Review review)
        {
            var item = await _reviewRepository.GetById(id);

            if (item == null)
            {
                return NotFound();
            }
            review.Id = item.Id;
            await _reviewRepository.Update(id, review);
            return NoContent();

        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(string id)
        {
            var item = _reviewRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            await _reviewRepository.Delete(id);
            return NoContent();
        }



    }
}
