using AutoMapper;
using Livraria.API.Dtos.Books;
using Livraria.API.Dtos.Publishers;
using Livraria.API.Dtos.Rentals;
using Livraria.API.Dtos.Users;
using Livraria.API.Models;

namespace Livraria.API.V1.Profiles
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<User, UserRequestDto>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
            CreateMap<Book, BookRequestDto>().ReverseMap();
            CreateMap<Book, BookResponseDto>().ReverseMap();
            CreateMap<Publisher, PublisherRequestDto>().ReverseMap();
            CreateMap<Publisher, PublisherResponseDto>().ReverseMap();
            CreateMap<Rental, RentalRequestDto>().ReverseMap();
            CreateMap<Rental, RentalResponseDto>().ReverseMap();
            CreateMap<Rental, RentalDevolutionDto>().ReverseMap();
        }
    }
}
