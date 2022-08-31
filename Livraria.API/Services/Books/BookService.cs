using Livraria.API.Data;
using Livraria.API.Models;

namespace Livraria.API.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IRepository _repo;
        public BookService(IRepository repo)
        {
            _repo = repo;
        }
        public Book BookCreate(Book model)
        {
            _repo.Add<Book>(model);
            if (_repo.SaveChanges())
            {
                return model;
            }

            return null;
        }
    }
}
