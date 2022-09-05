using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Models;
using System;

namespace Livraria.API.Services.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public RentalService(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Rental RentalCreate(Rental model)
        {
            var checkUser = _repo.GetUserById(model.UserId);
            if (checkUser == null)
            {
                return null;
            }

            var updateBook = _repo.GetBookById(model.BookId);
            if (updateBook.Quantity > 1)
            {
                return null;
            }
            else
            {
                updateBook.Quantity--;
                updateBook.TotalRented++;
            }

            DateTime currentDate = DateTime.Now;
            if (model.Rental_Date.Date < currentDate.Date)
            {
                return null;
            }

            if (model.Forecast_Date.Date < model.Rental_Date.Date)
            {
                return null;
            }

            _repo.Update<Book>(updateBook);
            if (_repo.SaveChanges())
            {
                _repo.Add<Rental>(model);
                if (_repo.SaveChanges())
                {
                    return model;
                }
                return null;
            }

            return null;
        }

        public Rental RentalUpdate(int rentalId, Rental model)
        {
            var rental = _repo.GetRentalById(rentalId);
            if (rental == null)
            {
                return null;
            }

            model.Id = rental.Id;
            model.UserId = rental.UserId;
            model.BookId = rental.BookId;
            model.Rental_Date = rental.Rental_Date;
            model.Forecast_Date = rental.Forecast_Date;

            if (model.Id != rentalId)
            {
                return null;
            }

            var updateBook = _repo.GetBookById(model.BookId);
            if (updateBook.TotalRented < 1)
            {
                return null;
            }
            else
            {
                updateBook.TotalRented--;
                updateBook.Quantity++;
            }

            if (model.Return_Date.Date < model.Rental_Date.Date)
            {
                return null;
            }

            if (model.Returned_Book != true)
            {
                return null;
            }


            _repo.Update<Book>(updateBook);
            if (_repo.SaveChanges())
            {
                _repo.Update<Rental>(model);
                if (_repo.SaveChanges())
                {
                    return model;
                }
                return null;
            }
            return null;
        }

        public Rental RentalDelete(int rentalId)
        {
            var rental = _repo.GetRentalById(rentalId);
            if (rental == null)
            {
                return null;
            }

            if (rental.Returned_Book != true)
            {
                return null;
            }

            _repo.Delete(rental);
            if (_repo.SaveChanges())
            {
                return rental;
            }

            return null;
        }
    }
}
