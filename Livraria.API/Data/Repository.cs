using AutoMapper;
using Livraria.API.Helpers;
using Livraria.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.API.Data
{
    public class Repository : IRepository
    {
        private readonly LibraryContext _context;
        public Repository(LibraryContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        // Usuários
        public User[] GetAllUsers()
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(u => u.Id);
            return query.ToArray();
        }

        public async Task<PageList<User>> GetAllUsersAsync(PageParams pageParams)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(u => u.Id);

            if (!string.IsNullOrEmpty(pageParams.Name))
            {
                query = query.Where(user => user.Name.ToUpper().Contains(pageParams.Name.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.City))
            {
                query = query.Where(user => user.City.ToUpper().Contains(pageParams.City.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.Address))
            {
                query = query.Where(user => user.Address.ToUpper().Contains(pageParams.Address.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.Email))
            {
                query = query.Where(user => user.Email.ToUpper().Contains(pageParams.Email.ToUpper()));
            }

            //return await query.ToListAsync();
            return await PageList<User>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public User GetUserById(int userId)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking()
                .OrderBy(u => u.Id)
                .Where(user => user.Id == userId);

            return query.FirstOrDefault();
        }

        // Livros
        public Book[] GetAllBooks(bool includePublisher = false)
        {
            IQueryable<Book> query = _context.Books;

            if (includePublisher)
            {
                query = query.Include(b => b.Publisher);
            }

            query = query.AsNoTracking().OrderBy(b => b.Id);

            return query.ToArray();
        }

        public async Task<PageList<Book>> GetAllBooksAsync(PageParams pageParams)
        {
            IQueryable<Book> query = _context.Books;

            query = query.Include(b => b.Publisher);

            query = query.AsNoTracking().OrderBy(b => b.Id);

            if (!string.IsNullOrEmpty(pageParams.Name))
            {
                query = query.Where(book => book.Name.ToUpper().Contains(pageParams.Name.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.Author))
            {
                query = query.Where(book => book.Author.ToUpper().Contains(pageParams.Author.ToUpper()));
            }

            if (pageParams.Launch != null)
            {
                query = query.Where(book => book.Launch == pageParams.Launch);
            }

            if (pageParams.Quantity != null)
            {
                query = query.Where(book => book.Quantity == pageParams.Quantity);
            }

            if (pageParams.TotalRented != null)
            {
                query = query.Where(book => book.TotalRented == pageParams.TotalRented);
            }

            //return await query.ToListAsync();
            return await PageList<Book>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Book[] GetAllBooksByPublisherId(int publisherId, bool includePublisher = false)
        {
            IQueryable<Book> query = _context.Books;

            if (includePublisher)
            {
                query = query.Include(b => b.Publisher);
            }

            query = query.AsNoTracking()
                .OrderBy(b => b.Id)
                .Where(publisher => publisher.Id == publisherId);

            return query.ToArray();
        }

        public Book GetBookById(int publisherId, bool includePublisher = false)
        {
            IQueryable<Book> query = _context.Books;

            if (includePublisher)
            {
                query = query.Include(b => b.Publisher);
            }

            query = query.AsNoTracking()
                .OrderBy(b => b.Id)
                .Where(publisher => publisher.Id == publisherId);

            return query.FirstOrDefault();
        }

        // Editoras
        public Publisher[] GetAllPublishers()
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(p => p.Id);
            return query.ToArray();
        }

        public async Task<PageList<Publisher>> GetAllPublishersAsync(PageParams pageParams)
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            if (!string.IsNullOrEmpty(pageParams.Name)) 
            {
                query = query.Where(publisher => publisher.Name.ToUpper().Contains(pageParams.Name.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.City))
            {
                query = query.Where(publisher => publisher.City.ToUpper().Contains(pageParams.City.ToUpper()));
            }



            //return await query.ToListAsync();
            return await PageList<Publisher>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Publisher GetPublisherById(int publisherId)
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(publisher => publisher.Id == publisherId);

            return query.FirstOrDefault();
        }

        // Alugueis
        public Rental[] GetAllRentals()
        {
            IQueryable<Rental> query = _context.Rentals;

            query = query.Include(r => r.User);
            query = query.Include(r => r.Book).ThenInclude(b => b.Publisher);

            query = query.AsNoTracking().OrderBy(r => r.Id);

            return query.ToArray();
        }

        public async Task<PageList<Rental>> GetAllRentalsAsync(PageParams pageParams)
        {
            IQueryable<Rental> query = _context.Rentals;

            query = query.Include(r => r.User);
            query = query.Include(r => r.Book).ThenInclude(b => b.Publisher);

            query = query.AsNoTracking().OrderBy(r => r.Id);

            if (pageParams.Quantity != null)
            {
                query = query.Where(book => book.Rental_Date == pageParams.Rental_Date);
            }

            if (pageParams.TotalRented != null)
            {
                query = query.Where(book => book.Forecast_Date == pageParams.Forecast_Date);
            }

            if (pageParams.TotalRented != null)
            {
                query = query.Where(book => book.Rental_Date == pageParams.Rental_Date);
            }

            //return await query.ToListAsync();
            return await PageList<Rental>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Rental[] GetAllRentalsByUserId(int userId)
        {
            IQueryable<Rental> query = _context.Rentals;

            query = query.Include(r => r.User);

            query = query.AsNoTracking()
                .OrderBy(r => r.Id)
                .Where(user => user.Id == userId);

            return query.ToArray();
        }

        public Rental[] GetAllRentalsByBookId(int bookId)
        {
            IQueryable<Rental> query = _context.Rentals;

            query = query.Include(r => r.Book);

            query = query.AsNoTracking()
                .OrderBy(r => r.Id)
                .Where(book => book.Id == bookId);

            return query.ToArray();
        }

        public Rental GetRentalById(int userId, int bookId)
        {
            IQueryable<Rental> query = _context.Rentals;

            query = query.Include(l => l.User);
            query = query.Include(l => l.Book);


            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(usuario => usuario.Id == userId)
                .Where(livro => livro.Id == bookId);

            return query.FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            IQueryable<User> query = _context.Users;
            query = query.Where(u => u.Email == email);
            return query.FirstOrDefault();
        }
    }
}
