using System;
using Livraria.API.Dtos.Books;
using Livraria.API.Dtos.Users;

namespace Livraria.API.Dtos.Rentals
{
    public class RentalRequestDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime Rental_Date { get; set; }
        public DateTime Forecast_Date { get; set; }
    }
}
