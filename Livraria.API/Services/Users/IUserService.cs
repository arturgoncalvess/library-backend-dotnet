using Livraria.API.Models;

namespace Livraria.API.Services.Users
{
    public interface IUserService
    {
        User UserCreate(User model);
        User UserUpdate(int id, User model);
        User UserDelete(int id);
    }
}
