using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Models;

namespace Livraria.API.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public BookService(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        public Book BookUpdate(int bookId, Book model)
        {
            var book = _repo.GetBookById(bookId);
            _mapper.Map(model, book);

            if (book == null)
            {
                return null;
            }

            if (bookId != model.Id)
            {
                return null;
            }

            _repo.Update<Book>(model);
            if (_repo.SaveChanges())
            {
                return model;
            }

            return null;
        }

        public Book BookDelete(int bookId)
        {
            var book = _repo.GetBookById(bookId);
            if (book == null)
            {
                return null;
            }

            var checkRental = _repo.GetAllRentalsByBookId(bookId);
            if (checkRental != null)
            {
                return null;
            }

            _repo.Delete(book);
            if (_repo.SaveChanges())
            {
                return book;
            }

            return null;
        }
    }
}
