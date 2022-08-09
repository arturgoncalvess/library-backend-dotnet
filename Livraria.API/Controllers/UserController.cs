using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Dtos;
using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public UserController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public IActionResult Get()
        {
            var users = _repo.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        // GET: api/user/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("User not found :(");

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        // POST api/user
        [HttpPost]
        public IActionResult Post(UserDto model)
        {
            var user = _mapper.Map<User>(model);

            _repo.Add(user);
            if(_repo.SaveChanges())
            {
                return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user)); 
            }

            return BadRequest("Unable to register user :(");
        }

        // PUT api/user/
        [HttpPut("{id}")]
        public IActionResult Put(int id, UserDto model)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("User not found :(");

            _mapper.Map(model, user);

            _repo.Update(user);
            if (_repo.SaveChanges())
            {
                return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user));
            }

            return BadRequest("Could not update user :(");
        }

        // DELETE api/user/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("User not found :(");

            _repo.Delete(user);
            if (_repo.SaveChanges())
            {
                return Ok("User deleted :)");
            }

            return  BadRequest("Could not delete user :(");
        }

    }
}
