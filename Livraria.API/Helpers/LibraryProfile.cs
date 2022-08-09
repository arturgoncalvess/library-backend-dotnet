using AutoMapper;
using Livraria.API.Dtos;
using Livraria.API.Models;

namespace Livraria.API.Helpers
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Rental, RentalDto>().ReverseMap();
        }      
    }
}
