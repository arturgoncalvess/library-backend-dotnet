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
    public class RentalController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public RentalController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/rental
        [HttpGet]
        public IActionResult Get()
        {
            var rentals = _repo.GetAllRentals();
            return Ok(_mapper.Map<IEnumerable<RentalDto>>(rentals));
        }


        // GET api/rental/byId
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rental = _repo.GetRentalById(id, id);
            if (rental == null) return BadRequest("Rental not found :(");

            var rentalDto = _mapper.Map<RentalDto>(rental);
            return Ok(rentalDto);
        }

        // POST api/rental
        [HttpPost]
        public IActionResult Post(RentalDto model)
        {
            var rental = _mapper.Map<Rental>(model);

            _repo.Add(rental);
            if (_repo.SaveChanges())
            {
                return Created($"/api/rental/{model.Id}", _mapper.Map<RentalDto>(rental));
            }

            return BadRequest("Unable to register rental :(");
        }

        // PUT api/rental/
        [HttpPut("{id}")]
        public IActionResult Put(int id, RentalDto model)
        {
            var rental = _repo.GetRentalById(id, id);
            if (rental == null) return BadRequest("Rental not found :(");

            _mapper.Map(model, rental);

            _repo.Update(rental);
            if (_repo.SaveChanges())
            {
                return Created($"/api/rental/{model.Id}", _mapper.Map<RentalDto>(rental));
            }

            return BadRequest("Unable to update rental :(");
        }

        // DELETE api/rental/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ren = _repo.GetRentalById(id, id);
            if (ren == null) return BadRequest("Rental not found :(");
            
            _repo.Delete(ren);
            if (_repo.SaveChanges())
            {
                return Ok("Rental deleted :)");
            }

            return BadRequest("Unable to delete rental :(");

        }
    }
}
