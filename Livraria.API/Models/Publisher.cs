namespace Livraria.API.Models
{
    public class Publisher
    {
        public Publisher() { }
        public Publisher(int id, string name, string city)
        {
            this.Id = id;
            this.Name = name;
            this.City = city;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

    }
}
