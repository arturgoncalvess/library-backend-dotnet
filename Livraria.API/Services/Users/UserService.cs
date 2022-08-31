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

        public User UserUpdate(int id, User model)
        {
            var user = _repo.GetUserById(id);
            _mapper.Map(model, user);

            if (user == null)
            {
                return null;
            }

            if (id != model.Id)
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

        public User UserDelete(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null)
            {
                return null;
            }

            int userId = id;
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