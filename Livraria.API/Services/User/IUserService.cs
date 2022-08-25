using Livraria.API.Dtos;

namespace Livraria.API.Services.User
{
    public interface IUserService
    {
        bool UserValidator(UserDto model);
    }
}
