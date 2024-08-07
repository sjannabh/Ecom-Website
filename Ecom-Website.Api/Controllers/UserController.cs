using Ecom_Website.Api.Repository.IRepository;
using Ecom_Website.Entity.Models.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_Website.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //Create
        [HttpPost("create")]
        public async Task Create(User user)
        {
            await _userRepository.Create(user);
        }

        //get all
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
           var res = await _userRepository.GetAll();
           return new JsonResult(res);
        }

        //get by Id
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var res = await _userRepository.GetById(id);
            return new JsonResult(res);
        }

        //update
        [HttpPut("update")]
        public async Task<IActionResult> Update(string id, User user)
        {
            var item = await _userRepository.GetById(id);
            user.Id = item.Id;
            await _userRepository.Update(id, user);
            return NoContent();

        }

        //delete
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userRepository.Delete(id);
            return NoContent();
        }
    }

}
