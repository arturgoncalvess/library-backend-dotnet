using System;

namespace Livraria.API.Dtos.Rentals
{
    public class RentalDevolutionDto
    {
        public DateTime Return_Date { get; set; }
        public bool Returned_Book { get; set; }
    }
}
