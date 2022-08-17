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
    public class PublisherController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor UserController de IRepository e IMapper
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public PublisherController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável para retornar todas as editoras
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var publishers = await _repo.GetAllPublishersAsync(pageParams);
            var publishersResult = _mapper.Map<IEnumerable<PublisherDto>>(publishers);

            Response.AddPagination(publishers.CurrentPage, publishers.PageSize, publishers.TotalCount, publishers.TotalPages);

            return Ok(publishersResult);
        }

        /// <summary>
        /// Método responsável por retornar apenas uma editora por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _repo.GetPublisherById(id);
            if (publisher == null) return BadRequest("Book not found :(");

            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            return Ok(publisherDto);
        }

        /// <summary>
        /// Método responsável em adicionar uma nova editora
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(PublisherDto model)
        {
            var publisher = _mapper.Map<Publisher>(model);

            _repo.Add(publisher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/publisher/{model.Id}", _mapper.Map<PublisherDto>(publisher));
            }

            return BadRequest("Unable to register publisher :(");
        }

        /// <summary>
        /// Método responsável em atualizar uma editora por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, PublisherDto model)
        {
            var publisher = _repo.GetPublisherById(id);
            if (publisher == null) return BadRequest("Publisher not found :(");

            _mapper.Map(model, publisher);

            _repo.Update(publisher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/publisher/{model.Id}", _mapper.Map<PublisherDto>(publisher));
            }

            return BadRequest("Unable to update publisher :(");
        }

        /// <summary>
        /// Método responsável em deletar uma editora por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _repo.GetPublisherById(id);
            if (publisher == null) return BadRequest("Publisher not found :(");

            _repo.Delete(publisher);
            if (_repo.SaveChanges())
            {
                return Ok("Publisher deleted :)");
            }

            return BadRequest("Unable to delete publisher :(");
        }

    }
}

