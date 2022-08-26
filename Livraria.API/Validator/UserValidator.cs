using FluentValidation;
using Livraria.API.Dtos;

namespace Livraria.API.Validator
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
        }
    }
}
