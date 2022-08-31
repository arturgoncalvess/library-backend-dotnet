using Livraria.API.Data;
using Livraria.API.Models;

namespace Livraria.API.Services.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly IRepository _repo;
        public RentalService(IRepository repo)
        {
            _repo = repo;
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
    }
}
