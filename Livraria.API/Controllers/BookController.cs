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
    public class BookController : ControllerBase 
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public BookController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/book
        [HttpGet]
        public IActionResult Get()
        {
            var books = _repo.GetAllBooks(true);
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        // GET: api/book/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _repo.GetBookById(id, true);
            if (book == null) return BadRequest("Book not found :(");

            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        // POST api/book
        [HttpPost]
        public IActionResult Post(BookDto model)
        {
            var book = _mapper.Map<Book>(model);

            _repo.Add(book);
            if (_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<BookDto>(book));
            }

            return BadRequest("Unable to register book :(");
        }

        // PUT api/book/
        [HttpPut("{id}")]
        public IActionResult Put(int id, BookDto model)
        {
            var book = _repo.GetBookById(id, true);
            if (book == null) return BadRequest("Book not found :(");

            _mapper.Map(model, book);

            _repo.Update(book);
            if (_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<BookDto>(book));
            }

            return BadRequest("Could not update book :(");
        }

        // DELETE api/book/
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            var boo = _repo.GetBookById(id, true);
            if (boo == null) return BadRequest("Book not found :(");

            _repo.Delete(boo);
            if (_repo.SaveChanges())
            {
                return Ok("Deleted book :)");
            }

            return BadRequest("Unable to delete book :(");
        }

    }
}
