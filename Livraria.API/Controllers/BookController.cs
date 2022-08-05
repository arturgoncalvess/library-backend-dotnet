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
    public class BookController : ControllerBase 
    {
        private readonly IRepository _repo;

        public BookController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _repo.GetAllBooks(true);
            return Ok(result);
        }

        // api/livro/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _repo.GetBookById(id, true);
            if (livro == null) return BadRequest("Book not found :(");
            return Ok(livro);
        }

        // api/book
        [HttpPost]
        public IActionResult Post(Book book)
        {
            _repo.Add(book);
            if (_repo.SaveChanges())
            {
                return Ok(book);
            }

            return BadRequest("Unable to register book :(");
        }

        // api/book
        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            var boo = _repo.GetBookById(id, true);
            if (boo == null) return BadRequest("Book not found :(");

            _repo.Update(book);
            if (_repo.SaveChanges())
            {
                return Ok("Updated book");
            }

            return BadRequest("Could not update book :(");
        }

        // api/book
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            var boo = _repo.GetBookById(id, true);
            if (boo == null) return BadRequest("Book not found :(");

            _repo.Delete(boo);
            if (_repo.SaveChanges())
            {
                return Ok("Deleted book");
            }

            return BadRequest("Unable to delete book :(");
        }

    }
}
