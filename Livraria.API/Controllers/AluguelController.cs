//using Livraria.API.Data;
//using Livraria.API.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Livraria.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LivroController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public LivroController(DataContext context)
//        {
//            _context = context;
//        }


//        [HttpGet]

//        public IActionResult Get()
//        {
//            return Ok(_context.Livros);
//        }

//        // api/usuario/byId
//        [HttpGet("byId")]
//        public IActionResult GetById(int id)
//        {
//            var livro = _context.Livros.FirstOrDefault(l => l.Id == id);
//            if (livro == null) return BadRequest("O livro não foi encontrado :( 1");
//            return Ok(livro);
//        }

//        // api/usuario/byName
//        [HttpGet("byName")]
//        public IActionResult GetByName(string nome)
//        {
//            var livro = _context.Livros.Where(l => l.Nome.Contains(nome));
//            if (livro == null) return BadRequest("Nenhum livro com " + livro + "encontrado 2");
//            return Ok(livro);
//        }

//        // POST
//        [HttpPost]
//        public IActionResult Post(Livro livro)
//        {
//            _context.Add(livro);
//            _context.SaveChanges();
//            return Ok(livro);
//        }

//        // PATCH
//        [HttpPatch("{id}")]
//        public IActionResult Patch(int id, Livro livro)
//        {
//            var liv = _context.Livros.FirstOrDefault(l => l.Id == id);
//            if (liv == null) return BadRequest("O livro não foi encontrado :( 3");
//            _context.Update(livro);
//            _context.SaveChanges();
//            return Ok(livro);
//        }
  
//        // PUT
//        [HttpPut("{id}")]
//        public IActionResult Put(int id, Livro livro)
//        {
//            var liv = _context.Livros.FirstOrDefault(l => l.Id == id);
//            if (liv == null) return BadRequest("O livro não foi encontrado :( 4");
//            _context.Update(livro);
//            _context.SaveChanges();
//            return Ok(livro);
//        }

//        // DELETE
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var livro = _context.Livros.FirstOrDefault(l => l.Id == id);
//            if (livro == null) return BadRequest("O livro não foi encontrado :( 5");
//            _context.Remove(livro);
//            _context.SaveChanges();
//            return Ok();
//        }

//    }
//}
