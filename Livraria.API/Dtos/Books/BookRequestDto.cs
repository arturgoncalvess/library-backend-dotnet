using System;
using Livraria.API.Dtos.Publishers;

namespace Livraria.API.Dtos.Books
{
    public class BookRequestDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public DateTime Launch { get; set; }
        public int Quantity { get; set; }
    }
}
