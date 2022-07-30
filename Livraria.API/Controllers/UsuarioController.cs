using Livraria.API.Data;
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
        private readonly DataContext _context;

        public UsuarioController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_context.Usuarios);
        }

        // api/usuario/byId
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return BadRequest("O usuário não foi encontrado :( 1");
            return Ok(usuario);
        }

        // api/usuario/byName
        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var usuario = _context.Usuarios.Where(u => u.Nome.Contains(nome));
            if (usuario == null) return BadRequest("Nenhum aluno com " + usuario + "encontrado 2");
            return Ok(usuario);
        }

        // POST
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }

        // POST
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Usuario usuario)
        {
            var usua = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return BadRequest("O usuário não foi encontrado :( 3");
            _context.Update(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            var usua = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return BadRequest("O usuário não foi encontrado :( 4");
            _context.Update(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return BadRequest("O usuário não foi encontrado :( 5");
            _context.Remove(usuario);
            _context.SaveChanges();
            return Ok();
        }

    }
}
