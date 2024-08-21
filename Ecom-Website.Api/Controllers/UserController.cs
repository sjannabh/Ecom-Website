using Ecom_Website.DataAccess.Models.Mongo;
using Ecom_Website.DataAccess.Repository.IRepository;
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
            var rev = await _userRepository.GetAll();
            if (rev == null)
            {
                return NotFound();
            }
            return new JsonResult(rev);
        }

        //get by Id
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var res = await _userRepository.GetById(id);
            return new JsonResult(res);
        }

        [HttpGet("getByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var res = await _userRepository.GetByIdEmail(email);
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
