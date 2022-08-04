using Livraria.API.Data;
using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private readonly IRepository _repo;

        public EditoraController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _repo.GetAllEditoras();
            return Ok(result);
        }

        // api/editora/byId
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var editora = _repo.GetEditoraById(id);
            if (editora == null) return BadRequest("A editora não foi encontrado :( 1");
            return Ok(editora);
        }

        // POST
        [HttpPost]
        public IActionResult Post(Editora editora)
        {
            _repo.Add(editora);
            if (_repo.SaveChanges())
            {
                return Ok(editora);
            }

            return BadRequest("Editora não foi cadastrado");
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var edi = _repo.GetEditoraById(id);
            if (edi == null) return BadRequest("O editora não foi encontrado :( 4");

            _repo.Update(edi);
            if (_repo.SaveChanges())
            {
                return Ok("Editora foi atualizado: " + edi);
            }

            return BadRequest("Editora não foi atualizado");
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var edi = _repo.GetEditoraById(id);
            if (edi == null) return BadRequest("O editora não foi encontrado :( 5");

            _repo.Delete(edi);
            if (_repo.SaveChanges())
            {
                return Ok("A editora foi deletado");
            }

            return BadRequest("A editora não foi deletado");
        }

    }
}

