using Livraria.API.Data;
using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRepository _repo;

        public RentalController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]

        public IActionResult Get()
        {
            var result = _repo.GetAllRentals();
            return Ok(result);
        }


        // api/rental/ById
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ren = _repo.GetRentalById(id, id);
            if (ren == null) return BadRequest("Rental not found :(");
            return Ok(ren);
        }

        // api/rental
        [HttpPost]
        public IActionResult Post(Rental rental)
        {
            _repo.Add(rental);
            if (_repo.SaveChanges())
            {
                return Ok(rental);
            }

            return BadRequest("Unable to register rental :(");
        }

        // api/rental
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var ren = _repo.GetRentalById(id, id);
            if (ren == null) return BadRequest("Rental not found :(");
            
            _repo.Update(ren);
            if (_repo.SaveChanges())
            {
                return Ok("Updated rental");
            }

            return BadRequest("Unable to update rental :(");
        }

        // api/rental
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ren = _repo.GetRentalById(id, id);
            if (ren == null) return BadRequest("Rental not found :(");
            
            _repo.Delete(ren);
            if (_repo.SaveChanges())
            {
                return Ok("Rental deleted");
            }

            return BadRequest("Unable to delete rental :(");

        }
    }
}
