using System;

namespace Livraria.API.Models
{
    public class Rental
    {
        public Rental() { }
        public Rental(int id, int user_id, int book_id, DateTime rental_date, DateTime forecast_date, DateTime return_date, bool returned_book)
        {
            this.Id = id;
            this.UserId = user_id;
            this.BookId = book_id;
            this.Rental_Date = rental_date;
            this.Forecast_Date = forecast_date;
            this.Return_Date = return_date;
            this.Returned_Book = returned_book;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime Rental_Date { get; set; } 
        public DateTime Forecast_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public bool? Returned_Book { get; set; }
    }
}