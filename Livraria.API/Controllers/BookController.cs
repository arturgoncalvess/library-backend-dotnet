using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Dtos.Books;
using Livraria.API.Helpers;
using Livraria.API.Models;
using Livraria.API.Services.Books;
using Microsoft.AspNetCore.Cors;
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
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class BookController : ControllerBase 
    {
        private readonly IBookService _bookService;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public BookController(IBookService service, IRepository repo, IMapper mapper)
        {
            _bookService = service;
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
            var booksResult = _mapper.Map<IEnumerable<BookResponseDto>>(books);

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
            var book = _repo.GetBookById(id);
            if (book == null) return BadRequest("Book not found.");

            var bookDto = _mapper.Map<BookResponseDto>(book);
            return Ok(bookDto);
        }

        [HttpGet("ByMaxRented")]
        public IActionResult GetByMaxRented()
        {
            var book = _repo.GetBooksByMaxRented();
            if (book == null) return BadRequest("Book not found.");

            return Ok(book);
        }

        /// <summary>
        /// Método responsável em adicionar um novo livro
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(BookRequestDto model)
        {
            var result = _bookService.BookCreate(_mapper.Map<Book>(model));

            if (result != null)
            {
                return Created($"/api/v1/book/{result.Id}", _mapper.Map<BookResponseDto>(result));
            }

            return BadRequest("Unable to register book.");
        }

        /// <summary>
        /// Método responsável em atualizar um livro por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, BookRequestDto model)
        {
            var result = _bookService.BookUpdate(id, _mapper.Map<Book>(model));

            if (result != null)
            {
                return Created($"/api/v1/book/{result.Id}", _mapper.Map<BookResponseDto>(result));
            }

            return BadRequest("Could not update book.");
        }

        /// <summary>
        /// Método responsável em deletar um livro por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            var result = _bookService.BookDelete(id);

            if (result != null)
            {
                return Ok("Deleted book.");
            }

            return BadRequest("Unable to delete book.");
        }

    }
}
