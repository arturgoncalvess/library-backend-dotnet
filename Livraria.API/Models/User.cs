namespace Livraria.API.Models
{
    public class User
    {
        public User() { }
        public User(int id, string name, string city, string address, string email)
        {
            this.Id = id;
            this.Name = name;
            this.City = city;
            this.Address = address;
            this.Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }    
        public string Email { get; set; }
    }
}
