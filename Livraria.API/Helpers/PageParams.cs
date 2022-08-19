using System;

namespace Livraria.API.Helpers
{
    public class PageParams
    {

        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Author { get; set; }
        public DateTime? Launch { get; set; }
        public int? Quantity { get; set; }
        public int? TotalRented { get; set; }
        public DateTime? Rental_Date { get; set; }
        public DateTime? Forecast_Date { get; set; }
        public DateTime? Return_date { get; set; }
    }
}
