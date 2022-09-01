using Livraria.API.Models;

namespace Livraria.API.Services.Books
{
    public interface IBookService
    {
        Book BookCreate(Book model);
        Book BookUpdate(int bookId, Book model);
        Book BookDelete(int bookId);
    }
}
