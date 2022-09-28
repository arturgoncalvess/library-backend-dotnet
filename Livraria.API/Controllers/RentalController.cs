using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Dtos.Rentals;
using Livraria.API.Helpers;
using Livraria.API.Models;
using Livraria.API.Services.Rentals;
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
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public RentalController(IRentalService service, IRepository repo, IMapper mapper)
        {
            _rentalService = service;
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável para retornar todos os alugueis
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var rentals = await _repo.GetAllRentalsAsync(pageParams);
            var rentalsResult = _mapper.Map<IEnumerable<RentalResponseDto>>(rentals);

            Response.AddPagination(rentals.CurrentPage, rentals.PageSize, rentals.TotalCount, rentals.TotalPages);

            return Ok(rentalsResult);
        }


        /// <summary>
        /// Método responsável por retornar apenas um usuário por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rental = _repo.GetRentalById(id);
            if (rental == null) return BadRequest("Rental not found.");

            var rentalDto = _mapper.Map<RentalResponseDto>(rental);
            return Ok(rentalDto);
        }

        /// <summary>
        /// Método responsável em adicionar um novo aluguel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(RentalRequestDto model)
        {
            var result = _rentalService.RentalCreate(_mapper.Map<Rental>(model));

            if (result != null)
            {
                return Created($"/api/v1/rental/{result.Id}", _mapper.Map<RentalResponseDto>(result));
            }

            return BadRequest("Unable to register rental.");
        }

        /// <summary>
        /// Método responsável em atualizar um aluguel por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, RentalDevolutionDto model)
        {
            var result = _rentalService.RentalUpdate(id, _mapper.Map<Rental>(model));

            if (result != null)
            {
                return Created($"/api/v1/rental/{result.Id}", _mapper.Map<RentalResponseDto>(result));
            }

            return BadRequest("Unable to update rental.");
        }

        /// <summary>
        /// Método responsável em deletar um aluguel por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _rentalService.RentalDelete(id);
            
            if (result != null)
            {
                return Ok("Rental deleted.");
            }

            return BadRequest("Unable to delete rental.");

        }
    }
}
