using Livraria.API.Data;
using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IRepository _repo;

        public PublisherController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _repo.GetAllPublishers();
            return Ok(result);
        }

        // api/publisher/ById
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var editora = _repo.GetPublisherById(id);
            if (editora == null) return BadRequest("Publisher not found :(");
            return Ok(editora);
        }

        // api/publisher
        [HttpPost]
        public IActionResult Post(Publisher publisher)
        {
            _repo.Add(publisher);
            if (_repo.SaveChanges())
            {
                return Ok(publisher);
            }

            return BadRequest("Unable to register publisher :(");
        }

        // api/publisher
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var pub = _repo.GetPublisherById(id);
            if (pub == null) return BadRequest("Publisher not found :(");

            _repo.Update(pub);
            if (_repo.SaveChanges())
            {
                return Ok("Updated publisher");
            }

            return BadRequest("Unable to update publisher :(");
        }

        // api/publisher
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pub = _repo.GetPublisherById(id);
            if (pub == null) return BadRequest("Publisher not found :(");

            _repo.Delete(pub);
            if (_repo.SaveChanges())
            {
                return Ok("Publisher deleted");
            }

            return BadRequest("Unable to delete publisher :(");
        }

    }
}

