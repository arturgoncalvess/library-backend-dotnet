using FluentValidation;
using Livraria.API.Models;

namespace Livraria.API.Validator
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.UserId)
                .NotNull()
                .WithMessage("Null User Id")
                .GreaterThan(0)
                .WithMessage("Minimum 1.");

            RuleFor(r => r.BookId)
                .NotNull()
                .WithMessage("Null Book Id")
                .GreaterThan(0)
                .WithMessage("Minimum 1.");
        }
    }
}
