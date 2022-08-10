using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Dtos;
using Livraria.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.API.Controllers
{
    /// <summary>
    /// ApiController
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor UserController de IRepository e IMapper
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public RentalController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável para retornar todos os alugueis
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var rentals = _repo.GetAllRentals();
            return Ok(_mapper.Map<IEnumerable<RentalDto>>(rentals));
        }


        /// <summary>
        /// Método responsável por retornar apenas um usuário por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rental = _repo.GetRentalById(id, id);
            if (rental == null) return BadRequest("Rental not found :(");

            var rentalDto = _mapper.Map<RentalDto>(rental);
            return Ok(rentalDto);
        }

        /// <summary>
        /// Método responsável em adicionar um novo aluguel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável em atualizar um aluguel por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável em deletar um aluguel por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
