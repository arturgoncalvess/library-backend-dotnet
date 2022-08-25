using Livraria.API.Data;
using Livraria.API.Models;

namespace Livraria.API.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository _repo;
        public UserService(IRepository repo)
        {
            _repo = repo;
        }

        public User UserCreate(User model)
        {
            if (model.Id != 0)
            {
                return null;
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                return null;
            }

            if (string.IsNullOrEmpty(model.City))
            {
                return null;
            }

            if (string.IsNullOrEmpty(model.Address))
            {
                return null;
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                return null;
            }

            var userEmail = _repo.GetUserByEmail(model.Email);
            if (userEmail != null)
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
    }
}
