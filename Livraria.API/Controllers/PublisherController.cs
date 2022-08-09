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
    public class PublisherController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public PublisherController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/publisher
        [HttpGet]
        public IActionResult Get()
        {
            var publishers = _repo.GetAllPublishers();
            return Ok(_mapper.Map<IEnumerable<PublisherDto>>(publishers));
        }

        // GET: api/publisher/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _repo.GetPublisherById(id);
            if (publisher == null) return BadRequest("Book not found :(");

            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            return Ok(publisherDto);
        }

        // POST api/publisher
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

        // PUT api/publisher/
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

        // DELETE api/publisher/
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

