using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public List<Usuario> Usuarios = new List<Usuario>()
        {
            new Usuario()
            {
                Id = 1,
                Nome = "Artur",
                Cidade = "Fortaleza",
                Endereco = "Rua A",
                Email = "Artur@gmail.com"
            },
            new Usuario()
            {
                Id = 2,
                Nome = "Art",
                Cidade = "Fortal",
                Endereco = "Rua B",
                Email = "Art@gmail.com"
            },
            new Usuario()
            {
                Id = 3,
                Nome = "Ark",
                Cidade = "Fort",
                Endereco = "Rua C",
                Email = "Ark@gmail.com"
            },
            new Usuario()
            {
                Id = 5,
                Nome = "Ana",
                Cidade = "Fort",
                Endereco = "Rua D",
                Email = "Anak@gmail.com"
            }
        };

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(Usuarios);
        }

        // api/usuario/byId
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return BadRequest("O usuário não foi encontrado :(");
            return Ok(usuario);
        }

        // api/usuario/byName
        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var usuario = Usuarios.Where(u => u.Nome.Contains(nome));
            if (usuario == null) return BadRequest("Nenhum aluno com " + usuario + "encontrado");
            return Ok(usuario);
        }

        // POST
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            return Ok(usuario);
        }

        // POST
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Usuario usuario)
        {
            return Ok(usuario);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            return Ok(usuario);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
