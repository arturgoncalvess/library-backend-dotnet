using System;

namespace Livraria.API.Models
{
    public class Rental
    {
        public Rental() { }
        public Rental(int id, int user_id, int book_id, int rental_date, int forecast_date, int return_date)
        {
            this.Id = id;
            this.UserId = user_id;
            this.BookId = book_id;
            this.Rental_Date = rental_date;
            this.Forecast_Date = forecast_date;
            this.Return_date = return_date;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Rental_Date { get; set; }
        public int Forecast_Date { get; set; }
        public int Return_date { get; set; }
    }
}