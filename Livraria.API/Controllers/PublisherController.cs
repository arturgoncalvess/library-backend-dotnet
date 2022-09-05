using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Dtos.Publishers;
using Livraria.API.Helpers;
using Livraria.API.Models;
using Livraria.API.Services.Publishers;
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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public PublisherController(IPublisherService service, IRepository repo, IMapper mapper)
        {
            _publisherService = service;
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
            var publishersResult = _mapper.Map<IEnumerable<PublisherResponseDto>>(publishers);

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
            if (publisher == null) return BadRequest("Book not found.");

            var publisherDto = _mapper.Map<PublisherResponseDto>(publisher);
            return Ok(publisherDto);
        }

        /// <summary>
        /// Método responsável em adicionar uma nova editora
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(PublisherRequestDto model)
        {
            var result = _publisherService.PublisherCreate(_mapper.Map<Publisher>(model));

            if (result != null)
            {
                return Created($"/api/v1/publisher/{result.Id}", _mapper.Map<PublisherResponseDto>(result));
            }

            return BadRequest("Unable to register publisher.");
        }

        /// <summary>
        /// Método responsável em atualizar uma editora por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, PublisherRequestDto model)
        {
            var result = _publisherService.PublisherUpdate(id, _mapper.Map<Publisher>(model));

            if (result != null)
            {
                return Created($"/api/publisher/{model.Id}", _mapper.Map<PublisherResponseDto>(result));
            }

            return BadRequest("Unable to update publisher.");
        }

        /// <summary>
        /// Método responsável em deletar uma editora por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _publisherService.PublisherDelete(id);

            if (result != null)
            {
                return Ok("Publisher deleted.");
            }

            return BadRequest("Unable to delete publisher");
        }

    }
}

