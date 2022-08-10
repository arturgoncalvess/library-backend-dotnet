namespace Livraria.API.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int BookId { get; set; }
        public BookDto Book { get; set; }
        public int Rental_Date { get; set; }
        public int Forecast_Date { get; set; } 
        public int Return_date { get; set; }
    }
}
