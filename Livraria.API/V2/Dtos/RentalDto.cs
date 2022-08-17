using System;

namespace Livraria.API.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int BookId { get; set; }
        public BookDto Book { get; set; }
        public DateTime Rental_Date { get; set; }
        public DateTime Forecast_Date { get; set; } 
        public DateTime Return_date { get; set; }
    }
}
