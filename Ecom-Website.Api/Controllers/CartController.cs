using Ecom_Website.DataAccess.Models;
using Ecom_Website.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_Website.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        //sqlconnection
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository repos)
        {
            _cartRepository = repos;
        }

        [HttpGet("getByUserId")]
        public ActionResult GetByUserId(string UserId)
        {
            var resp = _cartRepository.GetByUserId(UserId);
            return new JsonResult(resp);
        }

        [HttpGet("count")]
        public ActionResult GetCount(string UserId)
        {
            var resp = _cartRepository.GetCount(UserId);
            return new JsonResult(resp);
        }

        [HttpGet("total")]
        public ActionResult GetTotal(string UserId)
        {
            var resp = _cartRepository.GetTotal(UserId);
            return new JsonResult(resp);
        }


        [HttpPost("create")]
        public ActionResult Create(Cart Cart)
        {
            var item = _cartRepository.Create(Cart);
            return new JsonResult(item);
        }

        [HttpPut("update")]
        public ActionResult Update(int CartId, Cart Cart)
        {

            var item = _cartRepository.Update(CartId, Cart);
            return NoContent();
        }

        [HttpDelete("deleteLineItem")]
        public ActionResult DeleteLineItem(int CartId, string ProductId)
        {
            var item = _cartRepository.DeleteLineItem(CartId, ProductId);
            return new JsonResult(item);
        }

        [HttpDelete("delete")]
        public ActionResult Delete(int CartId)
        {
            _cartRepository.Delete(CartId);
            return NoContent();
        }


    }
}
