using Livraria.API.Models;

namespace Livraria.API.Services.Users
{
    public interface IUserService
    {
        User UserCreate(User model);
        User UserUpdate(int userId, User model);
        User UserDelete(int userId);
    }
}
