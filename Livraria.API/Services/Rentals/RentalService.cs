using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Models;

namespace Livraria.API.Services.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public RentalService(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Rental RentalCreate(Rental model)
        {
            _repo.Add<Rental>(model);
            if (_repo.SaveChanges())
            {
                return model;
            }

            return null;
        }

        public Rental RentalUpdate(int rentalId, Rental model)
        {
            var rental = _repo.GetRentalById(rentalId);
            _mapper.Map(model, rental);

            if (rental == null)
            {
                return null;
            }

            if (rentalId != model.Id)
            {
                return null;
            }

            _repo.Update<Rental>(model);
            if (_repo.SaveChanges())
            {
                return model;
            }

            return null;
        }

        public Rental RentalDelete(int rentalId)
        {
            var rental = _repo.GetRentalById(rentalId);
            if (rental == null)
            {
                return null;
            }

            _repo.Delete(rental);
            if (_repo.SaveChanges())
            {
                return rental;
            }

            return null;
        }
    }
}
