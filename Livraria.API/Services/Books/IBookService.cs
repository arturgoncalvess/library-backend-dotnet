using Livraria.API.Models;

namespace Livraria.API.Services.Books
{
    public interface IBookService
    {
        Book BookCreate(Book model);
    }
}
