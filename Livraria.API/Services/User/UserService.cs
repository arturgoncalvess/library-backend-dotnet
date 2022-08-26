using Livraria.API.Dtos;

namespace Livraria.API.Services.User
{
    public class UserService : IUserService
    {
        public bool UserValidator(UserDto model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                return true;
            }
            return false;
        }
    }
}
