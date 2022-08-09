using Livraria.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        User GetUserById(int userId);

        // Livros
        Book[] GetAllBooks(bool includeEditora = false);
        Book[] GetAllBooksByPublisherId(int publisherId, bool includePublisher = false);
        Book GetBookById(int publisherId, bool includePublisher = false);

        // Editoras
        Publisher[] GetAllPublishers();
        Publisher GetPublisherById(int publisherId);

        // Alugueis
        Rental[] GetAllRentals();
        Rental[] GetAllRentalsByUserId(int userId);
        Rental[] GetAllRentalsByBookId(int bookId);
        Rental GetRentalById(int userId, int bookId);
    }
}
