using Livraria.API.Models;

namespace Livraria.API.Services.Rentals
{
    public interface IRentalService
    {
        Rental RentalCreate(Rental model);
    }
}
