using AutoMapper;
using Livraria.API.Data;
using Livraria.API.Models;

namespace Livraria.API.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public UserService(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper; 
        }

        public User UserCreate(User model)
        {
            var checkEmail = _repo.GetUserByEmail(model.Email);
            if (checkEmail != null)
            {
                return null;
            }

            _repo.Add<User>(model);
            if (_repo.SaveChanges())
            {
                return model;
            }

            return null;
        }

        public User UserUpdate(int userId, User model)
        {
            var user = _repo.GetUserById(userId);
            _mapper.Map(model, user);

            if (user == null)
            {
                return null;
            }

            if (userId != model.Id)
            {
                return null;
            }

            var checkEmail = _repo.GetUserByEmail(model.Email);
            if (checkEmail != null && checkEmail.Id != model.Id)
            {
                return null;
            }

            _repo.Update<User>(model);
            if (_repo.SaveChanges())
            {
                return model;
            }

            return null;
        }

        public User UserDelete(int userId)
        {
            var user = _repo.GetUserById(userId);
            if (user == null)
            {
                return null;
            }

            var checkRental = _repo.GetAllRentalsByUserId(userId);
            if (checkRental != null)
            {
                return null;
            }

            _repo.Delete(user);
            if (_repo.SaveChanges())
            {
                return user;
            }

            return null;
        }
    }
}