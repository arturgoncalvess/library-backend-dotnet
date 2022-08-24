using Livraria.API.Data;
using Livraria.API.Dtos;
using Livraria.API.Models;

namespace Livraria.API.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository _userReposity;
        public UserService(IRepository repository)
        {
            _userReposity = repository;
        }

        public User UserCreate(User model)
        {
            var user = _userReposity.GetUserByEmail(model.Email);
            if (user != null)
            {
                return null;
            }
            else
            {
                _userReposity.Add<User>(model);
                return model;
            }

        }
    }
}
