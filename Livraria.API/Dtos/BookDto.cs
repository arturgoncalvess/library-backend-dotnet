namespace Livraria.API.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public int Launch { get; set; }
        public int Quantity { get; set; }
        public int TotalRented { get; set; }
    }
}
