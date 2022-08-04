using Livraria.API.Data;
using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase 
    {
        private readonly IRepository _repo;

        public LivroController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]

        public IActionResult Get()
        {
            var result = _repo.GetAllLivros(true);
            return Ok(result);
        }

        // api/livro/byId
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var livro = _repo.GetLivroById(id, true);
            if (livro == null) return BadRequest("O livro não foi encontrado :( 1");
            return Ok(livro);
        }

        // api/livro
        [HttpPost]
        public IActionResult Post(Livro livro)
        {
            _repo.Add(livro);
            if (_repo.SaveChanges())
            {
                return Ok(livro);
            }

            return BadRequest("O livro não foi cadastrado");
        }

        // api/livro
        [HttpPut("{id}")]
        public IActionResult Put(int id, Livro livro)
        {
            var lvr = _repo.GetLivroById(id, true);
            if (lvr == null) return BadRequest("O livro não foi encontrado :( 4");

            _repo.Update(lvr);
            if (_repo.SaveChanges())
            {
                return Ok("O livro foi atualizado");
            }

            return BadRequest("O livro não foi atualizado");
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var lvr = _repo.GetLivroById(id, true);
            if (lvr == null) return BadRequest("O livro não foi encontrado :( 5");

            _repo.Delete(lvr);
            if (_repo.SaveChanges())
            {
                return Ok("O livro foi deletado");
            }

            return BadRequest("O livro não foi deletado");
        }

    }
}
