using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Dtos;
using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    /// <summary>
    /// ApiController
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Método UserController para IRepository e IMapper
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public UserController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
         
        /// <summary>
        /// Construtor UserController de IRepository e IMapper
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _repo.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        /// <summary>
        /// Método responsável por retornar apenas um usuário por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("User not found :(");

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        /// <summary>
        /// Método responsável em adicionar um novo usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável em atualizar um usuário por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável em deletar um usuário por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
