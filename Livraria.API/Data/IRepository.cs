using Livraria.API.Helpers;
using Livraria.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Usuários
        User[] GetAllUsers();
        Task<PageList<User>> GetAllUsersAsync(PageParams pageParams);
        User GetUserByEmail(string email);
        User GetUserById(int userId);

        // Livros
        Book[] GetAllBooks();
        Task<PageList<Book>> GetAllBooksAsync(PageParams pageParams);
        Book GetAllBooksByPublisherId(int publisherId);
        Book GetBookById(int bookId);

        // Editoras
        Publisher[] GetAllPublishers();
        Task<PageList<Publisher>> GetAllPublishersAsync(PageParams pageParams);
        Publisher GetPublisherById(int publisherId);

        // Alugueis
        Rental[] GetAllRentals();
        Task<PageList<Rental>> GetAllRentalsAsync(PageParams pageParams);
        Rental GetAllRentalsByUserId(int userId);
        Rental GetAllRentalsByBookId(int bookId);
        Rental GetRentalById(int rentalId);
    }
}
