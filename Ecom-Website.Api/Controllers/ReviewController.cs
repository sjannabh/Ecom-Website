using Ecom_Website.Api.Repository.IRepository;
using Ecom_Website.Entity.Models.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
        public async Task<IActionResult> GetAll()
        {
            var rev = await _reviewRepository.GetAll();
            if(rev == null)
            {
                return NotFound();
            }
            return new JsonResult(rev);
        }

        //Get by ProductId
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var rev = await _reviewRepository.GetReviewById(id);
            if(rev == null)
            {
                return NotFound();
            }
            return new JsonResult(rev);
        }

        //Update review
        [HttpPut("update")]
        public async Task<IActionResult> Update(string id, Review review)
        {
            var item = await _reviewRepository.GetReviewById(id);

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
            var item = _reviewRepository.GetReviewById(id);
            if(item == null)
            {
                return NotFound();
            }
            await _reviewRepository.Delete(id);
            return NoContent();
        }



    }
}
