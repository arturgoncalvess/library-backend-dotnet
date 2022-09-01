using Livraria.API.Models;

namespace Livraria.API.Services.Rentals
{
    public interface IRentalService
    {
        Rental RentalCreate(Rental model);
        Rental RentalUpdate(int rentalId, Rental model);
        Rental RentalDelete(int rentalId);
    }
}
