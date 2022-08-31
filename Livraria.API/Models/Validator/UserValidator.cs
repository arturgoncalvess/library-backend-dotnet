using FluentValidation;
using Livraria.API.Models;

namespace Livraria.API.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Id)
                .Empty()
                .WithMessage("Id must be empty.");

            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Empty name.")
                .MinimumLength(3)
                .WithMessage("Minimum 3.")
                .MaximumLength(35)
                .WithMessage("Maximum 35.");

            RuleFor(u => u.City)
                .NotEmpty()
                .WithMessage("Empty name.")
                .MinimumLength(3)
                .WithMessage("Minimum 3.")
                .MaximumLength(35)
                .WithMessage("Maximum 35.");

            RuleFor(u => u.Address)
                .NotEmpty()
                .WithMessage("Empty name.")
                .MinimumLength(3)
                .WithMessage("Minimum 3.")
                .MaximumLength(35)
                .WithMessage("Maximum 35.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Empty name.")
                .EmailAddress()
                .WithMessage("Invalid email.");
        }
    }
}
