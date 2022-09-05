using System;
using Livraria.API.Dtos.Books;
using Livraria.API.Dtos.Users;

namespace Livraria.API.Dtos.Rentals
{
    public class RentalResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserResponseDto User { get; set; }
        public int BookId { get; set; }
        public BookResponseDto Book { get; set; }
        public DateTime Rental_Date { get; set; }
        public DateTime Forecast_Date { get; set; }
        public DateTime? Return_Date { get; set; }
        public bool Returned_Book { get; set; }
    }
}
