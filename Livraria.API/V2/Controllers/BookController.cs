using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Dtos;
using Livraria.API.Helpers;
using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    /// <summary>
    /// ApiController
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class BookController : ControllerBase 
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor UserController de IRepository e IMapper
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public BookController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável para retornar todos os livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var books = await _repo.GetAllBooksAsync(pageParams);
            var booksResult = _mapper.Map<IEnumerable<BookDto>>(books);

            Response.AddPagination(books.CurrentPage, books.PageSize, books.TotalCount, books.TotalPages);

            return Ok(booksResult);
        }

        /// <summary>
        /// Método responsável por retornar apenas um livro por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _repo.GetBookById(id, true);
            if (book == null) return BadRequest("Book not found :(");

            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        /// <summary>
        /// Método responsável em adicionar um novo livro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável em atualizar um livro por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável em deletar um livro por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
