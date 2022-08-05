using Livraria.API.Data;
using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repo;

        public UserController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _repo.GetAllUsers();
            return Ok(result);
        }

        // api/user/ById
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("User not found");
            return Ok(user);
        }

        // api/user
        [HttpPost]
        public IActionResult Post(User user)
        {
            _repo.Add(user);
            if(_repo.SaveChanges())
            {
                return Ok(user);
            }

            return BadRequest("Unable to register user :(");
        }

        // api/user
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var use = _repo.GetUserById(id);
            if (use == null) return BadRequest("User not found");

            _repo.Update(use);
            if (_repo.SaveChanges())
            {
                return Ok("Updated user");
            }

            return BadRequest("Could not update user :(");
        }

        // api/user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var use = _repo.GetUserById(id);
            if (use == null) return BadRequest("User not found");

            _repo.Delete(use);
            if (_repo.SaveChanges())
            {
                return Ok("User deleted");
            }

            return  BadRequest("Could not delete user :(");
        }

    }
}
