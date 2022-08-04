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
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository _repo;

        public UsuarioController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _repo.GetAllUsuarios();
            return Ok(result);
        }

        // api/usuario
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetUsuarioById(id);
            if (user == null) return BadRequest("O usuário não foi encontrado :( 1");
            return Ok(user);
        }

        // api/usuario
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            _repo.Add(usuario);
            if(_repo.SaveChanges())
            {
                return Ok(usuario);
            }

            return BadRequest("O usuário não foi cadastrado");
        }

        // api/usuario
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            var user = _repo.GetUsuarioById(id);
            if (user == null) return BadRequest("O usuário não foi encontrado :( 4");

            _repo.Update(user);
            if (_repo.SaveChanges())
            {
                return Ok("O usuário foi atualizado");
            }

            return BadRequest("O usuário não foi atualizado");
        }

        // api/usuario
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetUsuarioById(id);
            if (user == null) return BadRequest("O usuário não foi encontrado :( 5");

            _repo.Delete(user);
            if (_repo.SaveChanges())
            {
                return Ok("O usuário foi deletado");
            }

            return BadRequest("O usuário não foi deletado");
        }

    }
}
